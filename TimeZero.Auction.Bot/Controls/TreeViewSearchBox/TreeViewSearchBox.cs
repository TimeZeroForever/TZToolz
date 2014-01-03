using System;
using System.Drawing.Imaging;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TimeZero.Auction.Bot.Controls.TreeViewSearchBox
{
    public partial class TreeViewSearchBox : UserControl
    {

#region P/Invoke

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam,
                                                IntPtr lParam);

#endregion

#region Delegates and events

        public delegate void OnFilterNodeEvent(object s, TreeNode node, 
            string filter, out bool canHide);

        [Category("Action")]
        public event OnFilterNodeEvent FilterNode;

        [Category("Action")]
        public event EventHandler SearchCancelled;

        [Category("Action")]
        public event KeyEventHandler SearchKeyDown;

#endregion
        
#region Private members

        private bool _searching;
        private TreeView _treeView;
        private TreeNodeItems _treeNodeItems;
        private TreeNodeItems _treeNodesItemsFiltered;
        private SearchResultView _searchResultView;
        private SearchLevel _searchLevel;
        private TreeNodeCollection _rootNodes;
        private string _inactiveSearchText;
        private Color _inactiveColor;
        private Color _activeColor;
        private Color _mouseOnControlColor;
        private readonly Bitmap _clearButtonImage;
        private bool _mouseOnControl;
        private string _toolTip;
        private string _clearButtonToolTip;
        private TreeViewDrawMode _treeDrawMode;

#endregion

#region Properties

        [Browsable(false)]
        public TextBox TextBox
        {
            get { return tbSearch; }
        }

        [Browsable(true)]
        public override string Text
        {
            get { return tbSearch.Text; }
            set { tbSearch.Text = value; }
        }

        [Browsable(false)]
        public bool Searching
        {
            get { return _searching; }
        }

        [DefaultValue(null), Browsable(true)]
        public TreeView TreeView
        {
            get { return _treeView; }
            set
            {
                CancelSearch();
                _treeView = value;
                SearchLevel = _searchLevel;
            }
        }

        [DefaultValue(SearchResultView.List), Browsable(true)]
        public SearchResultView SearchResultView
        {
            get { return _searchResultView; }
            set
            {
                _searchResultView = value;
                if (_searching)
                {
                    ApplySearchFilter();
                }
            }
        }

        [DefaultValue(SearchLevel.Root), Browsable(true)]
        public SearchLevel SearchLevel
        {
            get { return _searchLevel; }
            set
            {
                _searchLevel = value;
                if (_treeView != null)
                {
                    _rootNodes = _searchLevel == SearchLevel.Root
                                     ? _treeView.Nodes
                                     : _treeView.Nodes.Count > 0
                                           ? _treeView.Nodes[0].Nodes
                                           : null;
                }
                if (_searching)
                {
                    ApplySearchFilter();
                }
            }
        }

        [DefaultValue("Search..."), Browsable(true)]
        public string InactiveSearchText
        {
            get { return _inactiveSearchText; }
            set
            {
                _inactiveSearchText = value;
                if (!_searching)
                {
                    SetInactiveSearchStyle();
                }
            }
        }

        [DefaultValue(null), Browsable(true)]
        public Color InactiveColor
        {
            get { return _inactiveColor; }
            set
            {
                _inactiveColor = value;
                if (!_searching)
                {
                    PaintFrame();
                    SetInactiveSearchStyle();
                }
            }
        }

        [DefaultValue(null), Browsable(true)]
        public Color ActiveColor
        {
            get { return _activeColor; }
            set
            {
                _activeColor = value;
                PaintFrame();
            }
        }

        [DefaultValue(null), Browsable(true)]
        public Color MouseOnControl
        {
            get { return _mouseOnControlColor; }
            set
            {
                _mouseOnControlColor = value;
                PaintFrame();
            }
        }

        [DefaultValue(null), Browsable(true)]
        public string ToolTip
        {
            get { return _toolTip; }
            set
            {
                _toolTip = value;
                toolTip.SetToolTip(this, _toolTip);
                toolTip.SetToolTip(pSearch, _toolTip);
                toolTip.SetToolTip(tbSearch, _toolTip);
            }
        }

        [DefaultValue(null), Browsable(true)]
        public string ClearButtonToolTipToolTip
        {
            get { return _clearButtonToolTip; }
            set
            {
                _clearButtonToolTip = value;
                toolTip.SetToolTip(btnClear, _clearButtonToolTip);
            }
        }

#endregion

#region Class functions

        public TreeViewSearchBox()
        {
            InitializeComponent();
            SetInactiveSearchStyle();

            _searchResultView = SearchResultView.List;
            _searchLevel = SearchLevel.Root;
            _inactiveSearchText = "Search...";
            _inactiveColor = Color.LightGray;
            _activeColor = Color.Gray;
            _mouseOnControlColor = Color.Silver;
            _toolTip = string.Empty;
            _clearButtonToolTip = string.Empty;
            _clearButtonImage = new Bitmap(btnClear.Image);
            btnClear.Image = null;
        }

        private void LockUpdate(Control parentCtrl)
        {
            SendMessage(parentCtrl.Handle, 0x000B, (IntPtr)0, (IntPtr)0);
        }

        private void UnlockUpdate(Control parentCtrl)
        {
            SendMessage(parentCtrl.Handle, 0x000B, (IntPtr)1, (IntPtr)0);
            parentCtrl.Invalidate(true);
        }

        private void LockTreeUpdate()
        {
            _treeDrawMode = _treeView.DrawMode;
            LockUpdate(_treeView);
            _treeView.DrawMode = TreeViewDrawMode.Normal;
        }

        private void UnlockTreeUpdate()
        {
            UnlockUpdate(_treeView);
            _treeView.DrawMode = _treeDrawMode;
        }

        public void CancelSearch()
        {
            if (_searching)
            {
                if (_treeView != null && _treeNodeItems != null)
                {
                    string[] selectedPath = _treeNodesItemsFiltered != null
                        ? _treeNodesItemsFiltered.GetSelectedNodeFullPath(_treeView.SelectedNode)
                        : null;

                    LockTreeUpdate();
                    _treeNodeItems.AssignToTreeNodeCollectionTree(_rootNodes);
                    SelectNodeByPath(selectedPath);
                    UnlockTreeUpdate();

                    _treeNodesItemsFiltered = _treeNodeItems = null;
                }
                _searching = false;
            }
            SetInactiveSearchStyle();
        }

        private void SelectNodeByPath(string[] fullPath)
        {
            try
            {
                if (fullPath != null && fullPath.Length > 0 && _rootNodes != null)
                {
                    TreeNode curNode = _rootNodes.Cast<TreeNode>().FirstOrDefault(
                        node => node.Text == fullPath[0]);
                    if (curNode != null)
                    {
                        for (int i = 1; i < fullPath.Length; i++)
                        {
                            string sub = fullPath[i];
                            curNode = curNode.Nodes[sub];
                        }
                        _treeView.SelectedNode = curNode;
                        if (_treeView.SelectedNode != null)
                        {
                            _treeView.SelectedNode.EnsureVisible();
                        }
                    }
                }
                else
                {
                    SelectFirstFoundNode();
                }
            }
            catch {}
        }

        private void ApplySearchFilterTree(TreeNodeItem nodeItem, string filter,
                                           ref bool canHide)
        {
            bool localCanHide = true;
            foreach (TreeNodeItem childNodeItem in nodeItem.Nodes)
            {
                ApplySearchFilterTree(childNodeItem, filter, ref localCanHide);
                if (!localCanHide)
                {
                    canHide = false;
                }
                nodeItem.IsNodeHidden = canHide;
            }

            if (nodeItem.IsNodeHidden)
            {
                FilterNode(this, nodeItem.Node, filter, out canHide);
                nodeItem.IsNodeHidden = canHide;
                nodeItem.IsFoundNode = !canHide;
            }
        }

        private void ApplySearchFilterList(TreeNodeItem nodeItem, string filter)
        {
            foreach (TreeNodeItem childNodeItem in nodeItem.Nodes)
            {
                ApplySearchFilterList(childNodeItem, filter);
            }
            FilterNode(this, nodeItem.Node, filter, out nodeItem.IsNodeHidden);
            nodeItem.IsFoundNode = !nodeItem.IsNodeHidden;
        }

        private void SelectFirstFoundNode()
        {
            TreeNode foundNode = _treeNodesItemsFiltered != null
                                     ? _treeNodesItemsFiltered.GetFirstFoundNode()
                                     : null;
            if (foundNode != null)
            {
                _treeView.SelectedNode = foundNode;
                foundNode.EnsureVisible();
            }
            else
            {
                _treeView.SelectedNode = null;
                if (_searchLevel == SearchLevel.FirstChild && _treeView.Nodes.Count > 0)
                {
                    _treeView.SelectedNode = _treeView.Nodes[0];
                }
            }
        }

        private void ApplySearchFilter()
        {
            if (_treeView != null && (_treeView.Nodes.Count > 0 || _searching) && 
                FilterNode != null && tbSearch.Text != _inactiveSearchText)
            {
                string filter = tbSearch.Text.Trim();
                if (string.IsNullOrEmpty(filter))
                {
                    if (_searching)
                    {
                        LockTreeUpdate();
                        _treeNodeItems.AssignToTreeNodeCollectionTree(_rootNodes);
                        UnlockTreeUpdate();
                        _treeNodesItemsFiltered = null;
                        SelectFirstFoundNode();
                    }
                    return;
                }

                //Store full TreeView nodes structure
                if (!_searching)
                {
                    _treeNodeItems = new TreeNodeItems(_rootNodes);
                    _searching = true;
                }

                //Create tree nodes filtered items
                _treeNodesItemsFiltered = new TreeNodeItems(_treeNodeItems, true);

                //Lock treeview update and clear nodes list
                LockTreeUpdate();
                _rootNodes.Clear();
                
                //Apply filter
                foreach (TreeNodeItem nodeItem in _treeNodesItemsFiltered.Nodes)
                {
                    if (_searchResultView == SearchResultView.Tree)
                    {
                        bool canHide = true;
                        ApplySearchFilterTree(nodeItem, filter, ref canHide);
                    }
                    else
                    {
                        ApplySearchFilterList(nodeItem, filter);
                    }
                }

                //Show filtered nodes
                if (_searchResultView == SearchResultView.Tree)
                {
                    _treeNodesItemsFiltered.AssignToTreeNodeCollectionTree(_rootNodes);
                }
                else
                {
                    _treeNodesItemsFiltered.AssignToTreeNodeCollectionList(_rootNodes);
                }

                //Expand all nodes
                _treeView.ExpandAll();

                //Select first found node
                SelectFirstFoundNode();

                //Unlock treeview update
                UnlockTreeUpdate();
            }
        }

        private void TbSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (SearchKeyDown != null)
            {
                SearchKeyDown(this, e);
                if (!e.Handled)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        BtnClearClick(sender, null);
                        if (SearchCancelled != null)
                        {
                            SearchCancelled(this, new EventArgs());
                        }
                        else if (_treeView != null)
                        {
                            _treeView.Focus();
                        }
                    }
                }
            }
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            CancelSearch();
        }

        private void TbSearchTextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void SetInactiveSearchStyle()
        {
            tbSearch.Text = _inactiveSearchText;
            tbSearch.Font = new Font(tbSearch.Font, FontStyle.Italic);
            tbSearch.ForeColor = Color.Silver;
            if (_treeView != null)
            {
                _treeView.Select();
            }
            Invalidate(true);
        }

        private void SetActiveSearchStyle()
        {
            tbSearch.Font = new Font(tbSearch.Font, FontStyle.Regular);
            tbSearch.ForeColor = Color.Black;
            if (tbSearch.Text == _inactiveSearchText)
            {
                tbSearch.Text = string.Empty;
            }
            Invalidate(true);
        }

        private void TbSearchEnter(object sender, EventArgs e)
        {
            SetActiveSearchStyle();
        }

        private void TbSearchLeave(object sender, EventArgs e)
        {
            string text = tbSearch.Text.Trim();
            if (string.IsNullOrEmpty(text) || text == _inactiveSearchText)
            {
                CancelSearch();
            }
        }

        private void PaintFrame()
        {
            Graphics graphics = Graphics.FromHwnd(Handle);
            Rectangle rect = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            rect.Width--; rect.Height--;
            Pen pen = new Pen(_mouseOnControl && !tbSearch.Focused
                                  ? _mouseOnControlColor
                                  : tbSearch.Focused
                                        ? _activeColor
                                        : _inactiveColor);
            graphics.DrawRectangle(pen, rect);
        }

        private void TreeViewSearchBoxPaint(object sender, PaintEventArgs e)
        {
            PaintFrame();
        }

        private void BtnClearPaint(object sender, PaintEventArgs e)
        {
            ColorMatrix matrix = new ColorMatrix { Matrix33 = tbSearch.Focused ? 0.9f : 0.3f };
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            e.Graphics.DrawImage(_clearButtonImage, btnClear.ClientRectangle, 0, 0,
                _clearButtonImage.Width, _clearButtonImage.Height, GraphicsUnit.Pixel,
                attributes);
        }

        private void TreeViewSearchBoxMouseEnter(object sender, EventArgs e)
        {
            if (!_mouseOnControl && !tbSearch.Focused)
            {
                _mouseOnControl = true;
                PaintFrame();
            }
        }

        private void TreeViewSearchBoxMouseLeave(object sender, EventArgs e)
        {
            if (_mouseOnControl && !tbSearch.Focused)
            {
                _mouseOnControl = false;
                PaintFrame();
            }
        }

        private void TreeViewSearchBoxMouseDown(object sender, MouseEventArgs e)
        {
            tbSearch.Focus();
        }

#endregion

    }
}