using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeZero.Auction.Bot.Classes.Common;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.GameItems;
using TimeZero.Auction.Bot.Classes.Network;
using TimeZero.Auction.Bot.Classes.Network.Acitons;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Game;
using TimeZero.Auction.Bot.Classes.TZProcess;
using TimeZero.Auction.Bot.ClassesInstances;
using TimeZero.Auction.Bot.Properties;
using AxShockwaveFlashObjects;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Threading;

namespace TimeZero.Auction.Bot.Forms
{
    public partial class frmMain : Form
    {

#region P/Invoke

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam,
                                                IntPtr lParam);

#endregion

#region Delegates

        delegate void OutLogData(string data);

#endregion

#region Private fields

        private bool _tzProcessHasPatched;

        private readonly GameClient _gameClient = Instance.GameClient;
        private readonly NetworkClient _networkClient = Instance.NetworkClient;
        private GameItemsGroupList _gameItemsGroups = Instance.GameItemsGroups;

        private readonly object _syncObject = new object();

        private long _networkDataOutLength;
        private long _networkDataInLength;

        private DateTime _startShoppingTime;

        private List<TreeNode> _gameItemsCheckedNodes;

        private readonly frmLoading _formLoading;

#endregion

#region Properties

        private bool AtLeastOneGameItemIsSelected
        {
            get
            {
                List<TreeNode> gameItemsSelectedNodes = GameItemsSelectedNodes;
                return gameItemsSelectedNodes.Count > 0 &&
                       gameItemsSelectedNodes[0] != null;
            }
        }

        private bool IsGameItemsInMultiSelectionMode
        {
            get { return tvGameItems.CheckBoxes; }
        }

        private List<TreeNode> GameItemsSelectedNodes
        {
            get
            {
                return !IsGameItemsInMultiSelectionMode
                    ? new List<TreeNode> { tvGameItems.SelectedNode }
                    : _gameItemsCheckedNodes;
            }
        }

        private object GameItemSelectedObject
        {
            get
            {
                return !IsGameItemsInMultiSelectionMode && tvGameItems.SelectedNode != null
                           ? tvGameItems.SelectedNode.Tag
                           : null;
            }
        }

#endregion

#region Class methods

        public frmMain()
        {
            Opacity = 0;
            _formLoading = new frmLoading().Show();

            InitializeComponent();
            InitializeEnvironment();
            UpdateInterface();

            flashPlayer.Base = Settings.Default.MainSWFFilePath;
            flashPlayer.Movie = Settings.Default.MainSWFFilePath;
            flashPlayer.OnReadyStateChange += player_OnReadyStateChange;
        }

        private void player_OnReadyStateChange(object sender, _IShockwaveFlashEvents_OnReadyStateChangeEvent e)
        {
            lock (_syncObject)
            {
                if (e.newState == 4 && !_tzProcessHasPatched)
                {
                    try
                    {
                        string vGlobal = flashPlayer.GetVariable("_root.container_connection");
                        if (vGlobal != "<undefined/>")
                        {
                            _tzProcessHasPatched = true;
                            TZProcessPatch.PatchCurrentProcess();
                            UpdateInterface();

                            _formLoading.Dispose();
                            Opacity = 100;
                            Focus();
                        }
                    }
                    catch { }
                }
            }
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

        private void OutLogMessage(string message)
        {
            lock (_syncObject)
            {
                tbLog.AppendText(string.Format("{0}{1}", message, Environment.NewLine));
            }
        }

        private void OutFullLogMessage(string message)
        {
            lock (_syncObject)
            {
                tbDetailedLog.AppendText(string.Format("{0}{1}{1}", message, Environment.NewLine));
                Thread.Sleep(0);
            }
        }

        private void InitializeEnvironment()
        {
            //Init game client
            _gameClient.Init(Settings.Default.LocalIP,
                             Settings.Default.UserName,
                             Settings.Default.Password,
                             Settings.Default.ClientVersion,
                             Settings.Default.ClientVersion2,
                             flashPlayer);

            //Init network client
            _networkClient.Init(Settings.Default.Server,
                                Settings.Default.Port,
                                Settings.Default.ChatServerPort);
            _networkClient.OnDataReceived += DataReceived;
            _networkClient.OnDataSended += DataSended;
            _networkClient.OnLogMessage += LogMessage;
            _networkClient.OnNetworkActivityOut += NetworkActivityOut;
            _networkClient.OnNetworkActivityIn += NetworkActivityIn;
            _networkClient.OnConnected += Connected;
            _networkClient.OnDisconnected += Disconnected;
            _networkClient.OnActionStepStarted += OnActionStepStarted;
            _networkClient.OnActionStepCompleted += OnActionStepCompleted;

            //Init game items groups
            try
            {
                if (File.Exists("gameItemsGroups.dat"))
                {
                    byte[] data = File.ReadAllBytes("gameItemsGroups.dat");
                    Instance.GameItemsGroups = new Serializer<GameItemsGroupList>().Deserialize(data);
                    _gameItemsGroups = Instance.GameItemsGroups;
                }
            }
            catch {}

            if (_gameItemsGroups.Empty)
            {
                _gameItemsGroups.InitializeDefaults();
            }
            RefreshGameItemsTreeView();

            //Init tool buttons
            btnOutLogs.Checked = Settings.Default.OutLogs;
            BtnOutLogsClick(null, null);
            btnOutDetailedLogs.Checked = Settings.Default.OutDetailedLogs;
            BtnOutDetailedLogsClick(null, null);
        }

        private void DeinitializeEnvironment()
        {
            _networkClient.Dispose();
        }

        private void UpdateInterface()
        {
            UpdateMainToolStrip();
            UpdateGameItemsInterface();
        }

        private void UpdateMainToolStrip()
        {
            Cursor = _tzProcessHasPatched ? Cursors.Default : Cursors.WaitCursor;
            btnConnect.Enabled = !_networkClient.Connected && _tzProcessHasPatched;
            btnDisconnect.Enabled = _networkClient.Connected && _tzProcessHasPatched;
            tcMain.Enabled = _tzProcessHasPatched;
        }

        private void FrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            DeinitializeEnvironment();
        }

        private void FrmMainKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    {
                        Connect();
                        break;
                    }
                case Keys.F9:
                    {
                        Disconnect();
                        break;
                    }
            }
        }

        private void BtnConnectClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void BtnDisconnectClick(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void TimerReconnectTick(object sender, EventArgs e)
        {
            timerReconnect.Enabled = !_networkClient.Connected;
            if (!_networkClient.Connected)
            {
                Connect();
            }
        }

        private void BtnOutLogsClick(object sender, EventArgs e)
        {
            _networkClient.OutLogs = btnOutLogs.Checked;
        }

        private void BtnOutDetailedLogsClick(object sender, EventArgs e)
        {
            _networkClient.OutDetailedLogs = btnOutDetailedLogs.Checked;
        }

        private void TimerNetworkActivityTick(object sender, EventArgs e)
        {
            int tc = Environment.TickCount;

            //slNetworkOut
            bool enabled = slNetworkOut.Tag != null &&
                           tc - (int) slNetworkOut.Tag < timerNetworkActivity.Interval;
            if (enabled != slNetworkOut.Enabled)
            {
                slNetworkOut.Enabled = enabled;
                slNetworkOut.Image = enabled
                                         ? Resources.server_from_client
                                         : Resources.server_from_client_grayed;
            }

            //slNetworkIn
            enabled = slNetworkIn.Tag != null &&
                           tc - (int)slNetworkIn.Tag < timerNetworkActivity.Interval;
            if (enabled != slNetworkIn.Enabled)
            {
                slNetworkIn.Enabled = enabled;
                slNetworkIn.Image = enabled
                                         ? Resources.server_to_client
                                         : Resources.server_to_client_grayed;
            }
        }

        private void OnNetworkActivityOut(int dataLength)
        {
            slNetworkOut.ToolTipText = BytesToString(_networkDataOutLength += dataLength) +
                " sended";
            slNetworkOut.Tag = Environment.TickCount;
        }

        private void OnNetworkActivityIn(int dataLength)
        {
            slNetworkIn.ToolTipText = BytesToString(_networkDataInLength += dataLength) +
                " received";
            slNetworkIn.Tag = Environment.TickCount;
        }

        private void BtnRunGameClick(object sender, EventArgs e)
        {
            string filePath = Settings.Default.TimeZeroExePath; 
            if (File.Exists(filePath))
            {
                Process.Start(filePath);
            }
        }

#endregion

#region Network connection methods

        private void Connect()
        {
            if (_tzProcessHasPatched && !_networkClient.Connected)
            {
                if (_networkClient.Connect(_gameClient))
                {
                    _networkClient.Login();
                }
            }
        }

        private void Disconnect()
        {
            if (_tzProcessHasPatched && _networkClient.Connected)
            {
                _networkClient.Disconnect();
            }
        }

        private void DataReceived(string data)
        {
            data = string.Format(">>> {1}:{0}{2}", Environment.NewLine, DateTime.Now, data);
            tbDetailedLog.BeginInvoke(new OutLogData(OutFullLogMessage), new object[] { data });
        }

        private void DataSended(string data)
        {
            data = string.Format("<<< {1}:{0}{2}", Environment.NewLine, DateTime.Now, data);
            tbDetailedLog.BeginInvoke(new OutLogData(OutFullLogMessage), new object[] { data });
        }

        private void NetworkActivityOut(int dataLength)
        {
            tbDetailedLog.BeginInvoke(new OnNetworkActivity(OnNetworkActivityOut), 
                new object[] { dataLength });
        }

        private void NetworkActivityIn(int dataLength)
        {
            tbDetailedLog.BeginInvoke(new OnNetworkActivity(OnNetworkActivityIn),
                new object[] { dataLength });
        }

        private void LogMessage(string message)
        {
            bool woDateTime = !string.IsNullOrEmpty(message) && 
                (message[0] == '-' || message[0] == '=' || message[0] == '\t');
            message = string.Format("{0}{1}", woDateTime ? "" : DateTime.Now + ": ", message);
            tbLog.BeginInvoke(new OutLogData(OutLogMessage), new object[] { message });
        }

        private void UpdateLastShoppingTime()
        {
            string time = DateTime.Now.Subtract(_startShoppingTime).ToString();
            lblLastShoppingTime.Text = time.Remove(time.IndexOf('.'));
            lblLastShoppingTime.ToolTipText = DateTime.Now.ToString();
        }

        private void SyncActionStepStarted(IActionStep actionStep)
        {
            string stepType = actionStep.GetType().ToString();
            lblActionInProgress.Text = stepType.Substring(stepType.IndexOf('_') + 1);
            lblActionInProgress.ToolTipText = DateTime.Now.ToString();
        }

        private void OnActionStepStarted(IActionStep actionStep) 
        {
            if (actionStep is GameStep_Shopping)
            {
                _startShoppingTime = DateTime.Now;
            }
            BeginInvoke(new OnActionStepStarted(SyncActionStepStarted), new[] { actionStep });
        }

        private void SyncActionStepCompleted(IActionStep actionStep)
        {
            lblActionInProgress.ToolTipText = string.Empty;
            lblActionInProgress.Text = "---";
        }

        private void OnActionStepCompleted(IActionStep actionStep, bool done)
        {
            if (actionStep is GameStep_Shopping && done)
            {
                BeginInvoke(new Action(UpdateLastShoppingTime));
                BeginInvoke(new Action(SaveGameItemsList));
                BeginInvoke(new Action(tbDetailedLog.Clear));
            }
            BeginInvoke(new OnActionStepStarted(SyncActionStepCompleted), new[] { actionStep });
        }

        private void Connected()
        {
            BeginInvoke(new Action(UpdateMainToolStrip));
        }

        private void SyncDisconnected()
        {
            UpdateMainToolStrip();
            timerReconnect.Enabled = true;
            lblActionInProgress.Text = "---";
            lblActionInProgress.ToolTipText = string.Empty;
            lblLastShoppingTime.Text = "---";
            lblLastShoppingTime.ToolTipText = string.Empty;
        }

        private void Disconnected()
        {
            BeginInvoke(new Action(SyncDisconnected));
        }

#endregion

#region Game items methods

        private void LockGameItemsTreeViewUpdate()
        {
            LockUpdate(tvGameItems);
            tvGameItems.DrawMode = TreeViewDrawMode.Normal;
        }

        private void UnlockGameItemsTreeViewUpdate()
        {
            UnlockUpdate(tvGameItems);
            tvGameItems.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        private void TvGameItemsAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                _gameItemsCheckedNodes.Add(e.Node);
            }
            else
            {
                _gameItemsCheckedNodes.Remove(e.Node);
            }
            UpdateGameItemsInterface();
        }

        private void TvsbItemsSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                tvsbItems.CancelSearch();
            }
        }

        private void TvsbItemsSearchCancelled(object sender, EventArgs e)
        {
            tvGameItems.Focus();
        }

        private void TvsbItemsFilterNode(object s, TreeNode node, string filter, out bool canHide)
        {
            canHide = !string.IsNullOrEmpty(filter) &&
                (node.Text.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) == -1 ||
                node.Tag == null);
        }

        private void BtnSaveItemsListClick(object sender, EventArgs e)
        {
            SaveGameItemsList();
        }

        private void TvItemsAfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateGameItemsInterface();
        }

        private void BtnRefreshItemsTreeClick(object sender, EventArgs e)
        {
            RefreshGameItemsTreeView();
        }

        private void SaveGameItemsList()
        {
            Cursor = Cursors.WaitCursor;

            //Save game items list
            Serializer<GameItemsGroupList> serializer = new Serializer<GameItemsGroupList>();
            byte[] gameItemsGroups = serializer.Serialize(_gameItemsGroups);
            File.WriteAllBytes("gameItemsGroups.dat", gameItemsGroups);

            Cursor = Cursors.Default;
        }

        private void RefreshGameItemsTreeView()
        {            
            //Prevented when multiselection mode
            if (!IsGameItemsInMultiSelectionMode)
            {
                Cursor = Cursors.WaitCursor;

                //Lock treeview update and clear
                LockGameItemsTreeViewUpdate();
                tvGameItems.Nodes.Clear();

                //Foreach group of game items
                foreach (GameItemsGroup group in _gameItemsGroups.Groups)
                {
                    //Create appropriate node
                    TreeNode groupNode = tvGameItems.Nodes.Add(group.Name);
                    groupNode.Tag = group;

                    //Foreach game item in the current group
                    List<KeyValuePair<TreeNode, List<TreeNode>>> nodesList = new
                        List<KeyValuePair<TreeNode, List<TreeNode>>>();
                    foreach (GameItemsSubGroup subGroup in group.SubGroups)
                    {
                        //Create subgroup node
                        TreeNode subGroupNode = new TreeNode(subGroup.Name) { Tag = subGroup };
                        List<TreeNode> itemsNodes = new List<TreeNode>();
                        nodesList.Add(new KeyValuePair<TreeNode, List<TreeNode>>(subGroupNode, itemsNodes));

                        foreach (GameItem item in subGroup.Items)
                        {
                            //Make item node caption
                            string text = string.Format("{0} {1}", item.Text, item.Modification).TrimEnd();

                            //Create appripriate tree node
                            TreeNode itemNode = new TreeNode(text) { Tag = item };

                            //Add item node
                            itemsNodes.Add(itemNode);
                        }
                    }

                    //Process items nodes
                    List<TreeNode> finalNodesList = new List<TreeNode>();
                    foreach (KeyValuePair<TreeNode, List<TreeNode>> itemsNodes in nodesList)
                    {
                        itemsNodes.Value.Sort((n1, n2) => string.Compare(n1.Text, n2.Text, true));

                        //Add item nodes
                        TreeNode subGroupNode = itemsNodes.Key;
                        subGroupNode.Nodes.AddRange(itemsNodes.Value.ToArray());
                        finalNodesList.Add(subGroupNode);
                    }

                    //Sort subgroups nodes
                    if (btnGameItemsOrderSubGroups.Checked)
                    {
                        finalNodesList.Sort((n1, n2) => string.Compare(n1.Text, n2.Text, true));
                    }

                    groupNode.Nodes.AddRange(finalNodesList.ToArray());
                }

                //Unlock treeview update
                UnlockGameItemsTreeViewUpdate();

                //Update items properties editor
                UpdateGameItemsInterface();
                Cursor = Cursors.Default;
            }
        }

        private void UpdateGameItemsInterface()
        {
            LockUpdate(scItems.Panel2);

            List<TreeNode> nodes = GameItemsSelectedNodes;

            object selectedObject = GameItemSelectedObject;
            pgItems.SelectedObject = selectedObject;
            
            lblItemIsNotSelected.Visible = selectedObject == null;
            pgItems.Visible = selectedObject != null;
            btnGameItemsSetDefaults.Enabled = (IsGameItemsInMultiSelectionMode && nodes.Count > 0) ||
                selectedObject is GameItemsGroup;
            btnGameItemRemove.Enabled = (IsGameItemsInMultiSelectionMode && nodes.Count > 0) || 
                (selectedObject != null && !(selectedObject is GameItemsGroup));

            btnGameItemsJumpToUnreviewed.Enabled = btnGameItemsOrderSubGroups.Enabled =
                btnGameItemsRefresh.Enabled = !IsGameItemsInMultiSelectionMode;

            GameItem gameItem = selectedObject as GameItem;
            if (gameItem != null && !gameItem.HasReviewed)
            {
                gameItem.HasReviewed = true;
                RepaintTreeNode(tvGameItems.SelectedNode.Parent);
                RepaintTreeNode(tvGameItems.SelectedNode.Parent.Parent);
            }

            UnlockUpdate(scItems.Panel2);
        }

        private void GameItemGroupsSetDefaults()
        {
            if (AtLeastOneGameItemIsSelected)
            {
                List<TreeNode> gameItemsSelectedNodes = GameItemsSelectedNodes;
                using (frmSetGameItemsDefaults form = new frmSetGameItemsDefaults())
                {
                    if (form.Execute())
                    {
                        Cursor = Cursors.WaitCursor;
                        foreach (TreeNode node in gameItemsSelectedNodes)
                        {
                            GameItemsGroup group = node.Tag as GameItemsGroup;
                            if (group != null)
                            {
                                foreach (GameItemsSubGroup subGroup in group.SubGroups)
                                {
                                    if (form.UseSubGroupsIgnoreForShopping)
                                    {
                                        subGroup.IgnoreForShopping = form.SubGroupsIgnoreForShopping;
                                    }
                                    if (form.UseSubGroupsUseExtendedShoppingRule)
                                    {
                                        subGroup.UseExtendedShoppingRule = form.SubGroupsUseExtendedShoppingRule;
                                    }
                                    if (form.UseSubGroupsShopPagesLimit)
                                    {
                                        subGroup.ShopPagesLimit = form.SubGroupsShopPagesLimit;
                                    }
                                    if (form.ApplyForGameItems)
                                    {
                                        foreach (GameItem gameItem in subGroup.Items)
                                        {
                                            float prewCost = gameItem.InstantPurchaseCost;
                                            if (form.InstantPurchaseByPerz)
                                            {
                                                float perz = form.InstantPurchasePerz;
                                                float defPurchaseCost = form.UseCurrentInstantPurchaseCostIfNoPublicCost
                                                    ? gameItem.InstantPurchaseCost : 0f;
                                                gameItem.InstantPurchaseCost = gameItem.FactoryCost > 0
                                                    ? (int)gameItem.FactoryCost / 100 * perz : defPurchaseCost;
                                            }
                                            else
                                            {
                                                gameItem.InstantPurchaseCost = form.InstantPurchaseCost;
                                            }
                                            gameItem.IgnoreForShopping = gameItem.InstantPurchaseCost == 0f;
                                            if (prewCost == 0f && gameItem.InstantPurchaseCost != 0f)
                                            {
                                                gameItem.HasReviewed = true;
                                                subGroup.IgnoreForShopping = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        GameItemsOffMultiSelectionMode();
                        tvGameItems.Refresh();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void BtnGameItemsSetDefaultsClick(object sender, EventArgs e)
        {
            GameItemGroupsSetDefaults();
        }

        private void TvGameItemsDrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            Color nodeColor = SystemColors.WindowText;
            if (e.Node.IsSelected && tvGameItems.Focused)
            {
                nodeColor = SystemColors.HighlightText;
            }
            else
            {
                object obj = e.Node.Tag;
                if (obj != null)
                {
                    //GameItemsGroup
                    GameItemsGroup group = obj as GameItemsGroup;
                    if (group != null)
                    {
                        bool done = false;

                        //Is someone of subgroups is contains not reviewed GameItem?
                        foreach (GameItemsSubGroup sg in group.SubGroups)
                        {
                            foreach (GameItem gi in sg.Items)
                            {
                                if (!gi.HasReviewed)
                                {
                                    nodeColor = Color.Blue;
                                    done = true;
                                    break;
                                }
                            }
                            if (done)
                            {
                                break;
                            }
                        }

                        //Is group ignore for shopping?
                        if (!done && group.IgnoreForShopping)
                        {
                            nodeColor = Color.Red;
                        }
                    }

                    //GameItemsSubGroup
                    GameItemsSubGroup subGroup = obj as GameItemsSubGroup;
                    if (subGroup != null)
                    {
                        bool done = false;
                        bool allItemsAreDisabled = true;

                        //If the subgroup contains not reviewed GameItem
                        foreach (GameItem gi in subGroup.Items)
                        {
                            if (!gi.HasReviewed)
                            {
                                nodeColor = Color.Blue;
                                done = true;
                                break;
                            }
                            allItemsAreDisabled &= gi.IgnoreForShopping;
                        }

                        //Is subgroup ignore for shopping?
                        if (!done && subGroup.IgnoreForShopping)
                        {
                            nodeColor = Color.Red;
                        }
                        else

                        //Are all items disabled?
                        if (allItemsAreDisabled)
                        {
                            nodeColor = Color.LightCoral;
                        }
                    }

                    //GameItem
                    GameItem gameItem = obj as GameItem;
                    if (gameItem != null)
                    {
                        //If the game item is not reviewed
                        if (!gameItem.HasReviewed)
                        {
                            nodeColor = Color.Blue;
                        }
                        else

                        //If the game item is doesn`t have an instant purchase cost
                        if (gameItem.InstantPurchaseCost == 0f)
                        {
                            nodeColor = Color.DimGray;
                        }
                        else

                        //If the game item is ignored for shopping
                        if (gameItem.IgnoreForShopping)
                        {
                            nodeColor = Color.Red;
                        }
                    }
                }
            }

            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 10, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont, rect, nodeColor, 
                Color.Empty, TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
        }

        private void TvGameItemsMouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = tvGameItems.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                tvGameItems.SelectedNode = node;
            }
        }

        private void GameItemsRemoveSelected()
        {
            if (AtLeastOneGameItemIsSelected)
            {
                LockGameItemsTreeViewUpdate();
                List<TreeNode> gameItemsSelectedNodes = GameItemsSelectedNodes;
                foreach (TreeNode node in gameItemsSelectedNodes)
                {
                    object selectedObject = node.Tag;
                    GameItem gameItem = selectedObject as GameItem;
                    GameItemsSubGroup subGroup = selectedObject as GameItemsSubGroup;

                    if (gameItem != null || subGroup != null)
                    {
                        //Remove selected GameItem
                        if (gameItem != null)
                        {
                            subGroup = tvGameItems.SelectedNode.Parent.Tag as GameItemsSubGroup;
                            if (subGroup != null)
                            {
                                subGroup.RemoveItem(gameItem);
                            }
                        }

                        //Remove selected GameItemsSubGroup
                        if (subGroup != null)
                        {
                            GameItemsGroup group = tvGameItems.SelectedNode.Parent.Tag as GameItemsGroup;
                            if (group != null)
                            {
                                group.RemoveSubGroup(subGroup);
                            }
                        }

                        //Remove current node
                        node.Remove();
                    }
                }
                GameItemsOffMultiSelectionMode();
                UnlockGameItemsTreeViewUpdate();
            }
        }

        private void BtnGameItemRemoveClick(object sender, EventArgs e)
        {
            GameItemsRemoveSelected();
        }

        private void PgItemsPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TreeNode node = tvGameItems.SelectedNode;
            GameItem gameItem = node.Tag as GameItem;
            if (gameItem != null)
            {
                node = node.Parent;
                GameItemsSubGroup subGroup = node.Tag as GameItemsSubGroup;
                if (subGroup != null)
                {
                    if ((gameItem.IgnoreForShopping || subGroup.IgnoreForShopping) &&
                       e.ChangedItem.Label == "Instant purchase cost" &&
                       (float)e.OldValue == 0f && (float)e.ChangedItem.Value > 0f)
                    {
                        gameItem.IgnoreForShopping = false;
                        subGroup.IgnoreForShopping = false;
                    }
                    RepaintTreeNode(node);
                }
            }
            RepaintTreeNode(tvGameItems.SelectedNode);
        }

        private TreeNode JumpToUnreviewedItem(TreeNode currentNode,
            HashSet<TreeNode> visitedNodes, ref bool finished)
        {
            //Start node was handled
            if (visitedNodes.Contains(currentNode))
            {
                finished = true;
                return null;
            }

            //Add current node into the visited nodes list
            visitedNodes.Add(currentNode);

            //Check if the node is GameItem and it`s not reviewed
            GameItem gameItem = currentNode.Tag as GameItem;
            if (gameItem != null && !gameItem.HasReviewed)
            {
                finished = true;
                return currentNode;
            }

            //Visit all child nodes
            TreeNode unreviewedNode;
            foreach (TreeNode node in currentNode.Nodes)
            {
                unreviewedNode = JumpToUnreviewedItem(node, visitedNodes,
                    ref finished);
                if (unreviewedNode != null || finished)
                {
                    return unreviewedNode;
                }
            }

            //Search for a next parent node
            TreeNode nextParentNode = null;
            while (nextParentNode == null)
            {
                if (currentNode.NextNode != null)
                {
                    nextParentNode = currentNode.NextNode;
                }
                else
                {
                    if (currentNode.Parent == null)
                    {
                        nextParentNode = currentNode.TreeView.Nodes[0];
                    }
                    else
                    {
                        currentNode = currentNode.Parent;
                    }
                }
            }

            //Visit parent node, which was found and isn`t visited
            if (!visitedNodes.Contains(nextParentNode))
            {
                unreviewedNode = JumpToUnreviewedItem(nextParentNode,
                    visitedNodes, ref finished);
                return unreviewedNode;
            }

            //Is parent node visited? Just exit
            return null;
        }

        private void JumpToUnreviewedGameItem()
        {
            //Prevented when multiselection mode
            if (!IsGameItemsInMultiSelectionMode)
            {
                //Search for next unreviewed node
                bool finished = false;
                HashSet<TreeNode> visitedNodes = new HashSet<TreeNode>();
                TreeNode currentNode = tvGameItems.SelectedNode ?? tvGameItems.Nodes[0];
                TreeNode unreviewedNode = JumpToUnreviewedItem(currentNode,
                    visitedNodes, ref finished);

                //Jump to node or show appropriate message if it`s hasn`t found
                if (unreviewedNode != null)
                {
                    tvGameItems.SelectedNode = unreviewedNode;
                    unreviewedNode.EnsureVisible();
                }
                else
                {
                    //If we need to update treeview before, do it
                    foreach (GameItemsGroup group in _gameItemsGroups.Groups)
                    {
                        foreach (GameItemsSubGroup subGroup in group.SubGroups)
                        {
                            foreach (GameItem gameItem in subGroup.Items)
                            {
                                if (!gameItem.HasReviewed)
                                {
                                    RefreshGameItemsTreeView();
                                    JumpToUnreviewedGameItem();
                                    return;
                                }
                            }
                        }
                    }

                    //otherwise there are really no unreviewed items
                    MessageBox.Show("All game items are reviewed", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnGameItemJumpToUnreviewedClick(object sender, EventArgs e)
        {
            JumpToUnreviewedGameItem();
        }

        private void TvGameItemsPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        {
                            SaveGameItemsList();
                            break;
                        }
                    case Keys.R:
                        {
                            RefreshGameItemsTreeView();
                            break;
                        }
                    case Keys.N:
                        {
                            JumpToUnreviewedGameItem();
                            break;
                        }
                }
            }
        }

        private void TvGameItemsDoubleClick(object sender, EventArgs e)
        {
            if (tvGameItems.SelectedNode != null &&
                tvGameItems.SelectedNode.Tag as GameItem != null)
            {
                pgItems.Focus();
            }
        }

        private void BtnGameItemsMultiSelectClick(object sender, EventArgs e)
        {
            GameItemsToggleMultiSelectionMode();
        }

        private void GameItemsToggleMultiSelectionMode()
        {
            Cursor = Cursors.WaitCursor;
            LockGameItemsTreeViewUpdate();

            tvGameItems.CheckBoxes = !tvGameItems.CheckBoxes;
            _gameItemsCheckedNodes = new List<TreeNode>();

            btnGameItemsMultiSelect.Image = tvGameItems.CheckBoxes
                ? Resources.forbidden : Resources.checks;

            UnlockGameItemsTreeViewUpdate();
            UpdateGameItemsInterface();
            Cursor = Cursors.Default;
        }

        private void GameItemsOffMultiSelectionMode()
        {
            if (IsGameItemsInMultiSelectionMode)
            {
                GameItemsToggleMultiSelectionMode();
            }
        }

#endregion

#region Helpers

        private void RepaintTreeNode(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                treeNode.TreeView.Invalidate(treeNode.Bounds);
            }
        }

        private string BytesToString(long byteCount)
        {
            string[] suf = { " bytes", " KB", " MB", " GB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }

#endregion

    }
}
