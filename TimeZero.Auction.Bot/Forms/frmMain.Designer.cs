using TimeZero.Auction.Bot.Controls;
using TimeZero.Auction.Bot.Controls.Header;
using TimeZero.Auction.Bot.Controls.TreeViewSearchBox;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpItems = new System.Windows.Forms.TabPage();
            this.scItems = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsGameItems = new System.Windows.Forms.ToolStrip();
            this.btnGameItemsSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGameItemsActions = new System.Windows.Forms.ToolStripDropDownButton();
            this.removeAllUnreviewedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllZerocostItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGameItemsSetDefaults = new System.Windows.Forms.ToolStripButton();
            this.btnGameItemRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGameItemsMultiSelect = new System.Windows.Forms.ToolStripButton();
            this.btnGameItemsRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnGameItemsOrderSubGroups = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGameItemsJumpToUnreviewed = new System.Windows.Forms.ToolStripButton();
            this.hAttributesList = new TimeZero.Auction.Bot.Controls.Header.Header();
            this.tvsbItems = new TimeZero.Auction.Bot.Controls.TreeViewSearchBox.TreeViewSearchBox();
            this.tvGameItems = new System.Windows.Forms.TreeView();
            this.pgItems = new System.Windows.Forms.PropertyGrid();
            this.header1 = new TimeZero.Auction.Bot.Controls.Header.Header();
            this.lblItemIsNotSelected = new System.Windows.Forms.Label();
            this.tpIMS = new System.Windows.Forms.TabPage();
            this.pIMSBack = new System.Windows.Forms.Panel();
            this.tbIMS = new System.Windows.Forms.TextBox();
            this.tpChat = new System.Windows.Forms.TabPage();
            this.pChatBack = new System.Windows.Forms.Panel();
            this.tbChat = new System.Windows.Forms.RichTextBox();
            this.tpLogs = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.tcLogs = new System.Windows.Forms.TabControl();
            this.tpGeneralLogs = new System.Windows.Forms.TabPage();
            this.pGeneralLogsBack = new System.Windows.Forms.Panel();
            this.tbGeneralLogs = new System.Windows.Forms.TextBox();
            this.tpActionsLogs = new System.Windows.Forms.TabPage();
            this.pActionsLogsBack = new System.Windows.Forms.Panel();
            this.tbActionsLogs = new System.Windows.Forms.TextBox();
            this.tpDetailedLogs = new System.Windows.Forms.TabPage();
            this.pDetailedLogsBack = new System.Windows.Forms.Panel();
            this.tbDetailedLogs = new System.Windows.Forms.TextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOutInstantMessages = new System.Windows.Forms.ToolStripButton();
            this.btnOutChatMessages = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOutGeneralLogs = new System.Windows.Forms.ToolStripButton();
            this.btnOutActionsLogs = new System.Windows.Forms.ToolStripButton();
            this.btnOutDetailedLogs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunGame = new System.Windows.Forms.ToolStripButton();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.flashPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.timerReconnect = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.slNetworkOut = new System.Windows.Forms.ToolStripStatusLabel();
            this.slNetworkIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblActionInProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNetworkActivity = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tcMain.SuspendLayout();
            this.tpItems.SuspendLayout();
            this.scItems.Panel1.SuspendLayout();
            this.scItems.Panel2.SuspendLayout();
            this.scItems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsGameItems.SuspendLayout();
            this.tpIMS.SuspendLayout();
            this.pIMSBack.SuspendLayout();
            this.tpChat.SuspendLayout();
            this.pChatBack.SuspendLayout();
            this.tpLogs.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcLogs.SuspendLayout();
            this.tpGeneralLogs.SuspendLayout();
            this.pGeneralLogsBack.SuspendLayout();
            this.tpActionsLogs.SuspendLayout();
            this.pActionsLogsBack.SuspendLayout();
            this.tpDetailedLogs.SuspendLayout();
            this.pDetailedLogsBack.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).BeginInit();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpItems);
            this.tcMain.Controls.Add(this.tpIMS);
            this.tcMain.Controls.Add(this.tpChat);
            this.tcMain.Controls.Add(this.tpLogs);
            this.tcMain.Location = new System.Drawing.Point(12, 30);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(660, 489);
            this.tcMain.TabIndex = 0;
            // 
            // tpItems
            // 
            this.tpItems.Controls.Add(this.scItems);
            this.tpItems.Location = new System.Drawing.Point(4, 23);
            this.tpItems.Name = "tpItems";
            this.tpItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpItems.Size = new System.Drawing.Size(652, 462);
            this.tpItems.TabIndex = 2;
            this.tpItems.Text = "Game items";
            this.tpItems.UseVisualStyleBackColor = true;
            // 
            // scItems
            // 
            this.scItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scItems.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scItems.Location = new System.Drawing.Point(3, 3);
            this.scItems.Name = "scItems";
            // 
            // scItems.Panel1
            // 
            this.scItems.Panel1.Controls.Add(this.panel1);
            this.scItems.Panel1.Controls.Add(this.hAttributesList);
            this.scItems.Panel1.Controls.Add(this.tvsbItems);
            this.scItems.Panel1.Controls.Add(this.tvGameItems);
            // 
            // scItems.Panel2
            // 
            this.scItems.Panel2.Controls.Add(this.pgItems);
            this.scItems.Panel2.Controls.Add(this.header1);
            this.scItems.Panel2.Controls.Add(this.lblItemIsNotSelected);
            this.scItems.Size = new System.Drawing.Size(646, 456);
            this.scItems.SplitterDistance = 230;
            this.scItems.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tsGameItems);
            this.panel1.Location = new System.Drawing.Point(-1, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 26);
            this.panel1.TabIndex = 4;
            // 
            // tsGameItems
            // 
            this.tsGameItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsGameItems.AutoSize = false;
            this.tsGameItems.Dock = System.Windows.Forms.DockStyle.None;
            this.tsGameItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGameItemsSaveAll,
            this.toolStripSeparator4,
            this.btnGameItemsActions,
            this.btnGameItemsSetDefaults,
            this.btnGameItemRemove,
            this.toolStripSeparator6,
            this.btnGameItemsMultiSelect,
            this.btnGameItemsRefresh,
            this.btnGameItemsOrderSubGroups,
            this.toolStripSeparator3,
            this.btnGameItemsJumpToUnreviewed});
            this.tsGameItems.Location = new System.Drawing.Point(-8, 0);
            this.tsGameItems.Name = "tsGameItems";
            this.tsGameItems.Size = new System.Drawing.Size(236, 25);
            this.tsGameItems.TabIndex = 5;
            // 
            // btnGameItemsSaveAll
            // 
            this.btnGameItemsSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsSaveAll.Image = global::TimeZero.Auction.Bot.Properties.Resources.disk_blue;
            this.btnGameItemsSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsSaveAll.Name = "btnGameItemsSaveAll";
            this.btnGameItemsSaveAll.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsSaveAll.Text = "Save items list";
            this.btnGameItemsSaveAll.Click += new System.EventHandler(this.BtnSaveItemsListClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGameItemsActions
            // 
            this.btnGameItemsActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllUnreviewedItemsToolStripMenuItem,
            this.removeAllZerocostItemsToolStripMenuItem});
            this.btnGameItemsActions.Image = global::TimeZero.Auction.Bot.Properties.Resources.lightning;
            this.btnGameItemsActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsActions.Name = "btnGameItemsActions";
            this.btnGameItemsActions.Size = new System.Drawing.Size(29, 22);
            this.btnGameItemsActions.Text = "Actions";
            // 
            // removeAllUnreviewedItemsToolStripMenuItem
            // 
            this.removeAllUnreviewedItemsToolStripMenuItem.Name = "removeAllUnreviewedItemsToolStripMenuItem";
            this.removeAllUnreviewedItemsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeAllUnreviewedItemsToolStripMenuItem.Text = "Remove all unreviewed items";
            this.removeAllUnreviewedItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllUnreviewedItemsToolStripMenuItemClick);
            // 
            // removeAllZerocostItemsToolStripMenuItem
            // 
            this.removeAllZerocostItemsToolStripMenuItem.Name = "removeAllZerocostItemsToolStripMenuItem";
            this.removeAllZerocostItemsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeAllZerocostItemsToolStripMenuItem.Text = "Remove all zero-cost items";
            this.removeAllZerocostItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllZerocostItemsToolStripMenuItemClick);
            // 
            // btnGameItemsSetDefaults
            // 
            this.btnGameItemsSetDefaults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsSetDefaults.Image = global::TimeZero.Auction.Bot.Properties.Resources.gear_ok;
            this.btnGameItemsSetDefaults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsSetDefaults.Name = "btnGameItemsSetDefaults";
            this.btnGameItemsSetDefaults.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsSetDefaults.Text = "Set defaults";
            this.btnGameItemsSetDefaults.Click += new System.EventHandler(this.BtnGameItemsSetDefaultsClick);
            // 
            // btnGameItemRemove
            // 
            this.btnGameItemRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemRemove.Image = global::TimeZero.Auction.Bot.Properties.Resources.delete2;
            this.btnGameItemRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemRemove.Name = "btnGameItemRemove";
            this.btnGameItemRemove.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemRemove.Text = "Delete selected object";
            this.btnGameItemRemove.Click += new System.EventHandler(this.BtnGameItemRemoveClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGameItemsMultiSelect
            // 
            this.btnGameItemsMultiSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsMultiSelect.Image = global::TimeZero.Auction.Bot.Properties.Resources.checks;
            this.btnGameItemsMultiSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsMultiSelect.Name = "btnGameItemsMultiSelect";
            this.btnGameItemsMultiSelect.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsMultiSelect.Text = "Toggle multiselection mode";
            this.btnGameItemsMultiSelect.Click += new System.EventHandler(this.BtnGameItemsMultiSelectClick);
            // 
            // btnGameItemsRefresh
            // 
            this.btnGameItemsRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGameItemsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsRefresh.Image = global::TimeZero.Auction.Bot.Properties.Resources.refresh;
            this.btnGameItemsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsRefresh.Name = "btnGameItemsRefresh";
            this.btnGameItemsRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsRefresh.Text = "Refresh list [Ctrl+R]";
            this.btnGameItemsRefresh.Click += new System.EventHandler(this.BtnRefreshItemsTreeClick);
            // 
            // btnGameItemsOrderSubGroups
            // 
            this.btnGameItemsOrderSubGroups.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGameItemsOrderSubGroups.CheckOnClick = true;
            this.btnGameItemsOrderSubGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsOrderSubGroups.Image = global::TimeZero.Auction.Bot.Properties.Resources.sort_az_descending;
            this.btnGameItemsOrderSubGroups.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsOrderSubGroups.Name = "btnGameItemsOrderSubGroups";
            this.btnGameItemsOrderSubGroups.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsOrderSubGroups.Text = "Order subgroups";
            this.btnGameItemsOrderSubGroups.Click += new System.EventHandler(this.BtnRefreshItemsTreeClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGameItemsJumpToUnreviewed
            // 
            this.btnGameItemsJumpToUnreviewed.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGameItemsJumpToUnreviewed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGameItemsJumpToUnreviewed.Image = global::TimeZero.Auction.Bot.Properties.Resources.redo;
            this.btnGameItemsJumpToUnreviewed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGameItemsJumpToUnreviewed.Name = "btnGameItemsJumpToUnreviewed";
            this.btnGameItemsJumpToUnreviewed.Size = new System.Drawing.Size(23, 22);
            this.btnGameItemsJumpToUnreviewed.Text = "Jump to next unreviewed item [Ctrl+N]";
            this.btnGameItemsJumpToUnreviewed.Click += new System.EventHandler(this.BtnGameItemJumpToUnreviewedClick);
            // 
            // hAttributesList
            // 
            this.hAttributesList.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.hAttributesList.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.hAttributesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hAttributesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hAttributesList.Caption = "Game items list";
            this.hAttributesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.hAttributesList.Font = new System.Drawing.Font("Calibri", 9F);
            this.hAttributesList.ForeColor = System.Drawing.Color.Black;
            this.hAttributesList.Location = new System.Drawing.Point(0, 0);
            this.hAttributesList.Name = "hAttributesList";
            this.hAttributesList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.hAttributesList.Size = new System.Drawing.Size(228, 21);
            this.hAttributesList.TabIndex = 4;
            this.hAttributesList.TabStop = false;
            this.hAttributesList.TopGradientColor = System.Drawing.Color.Lavender;
            // 
            // tvsbItems
            // 
            this.tvsbItems.ActiveColor = System.Drawing.Color.Gray;
            this.tvsbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvsbItems.ClearButtonToolTipToolTip = "";
            this.tvsbItems.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tvsbItems.InactiveColor = System.Drawing.Color.LightGray;
            this.tvsbItems.Location = new System.Drawing.Point(-1, 435);
            this.tvsbItems.MouseOnControl = System.Drawing.Color.Silver;
            this.tvsbItems.Name = "tvsbItems";
            this.tvsbItems.Padding = new System.Windows.Forms.Padding(1);
            this.tvsbItems.Size = new System.Drawing.Size(231, 20);
            this.tvsbItems.TabIndex = 0;
            this.tvsbItems.ToolTip = "";
            this.tvsbItems.TreeView = this.tvGameItems;
            this.tvsbItems.FilterNode += new TimeZero.Auction.Bot.Controls.TreeViewSearchBox.TreeViewSearchBox.OnFilterNodeEvent(this.TvsbItemsFilterNode);
            this.tvsbItems.SearchCancelled += new System.EventHandler(this.TvsbItemsSearchCancelled);
            this.tvsbItems.SearchKeyDown += new System.Windows.Forms.KeyEventHandler(this.TvsbItemsSearchKeyDown);
            // 
            // tvGameItems
            // 
            this.tvGameItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvGameItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvGameItems.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvGameItems.FullRowSelect = true;
            this.tvGameItems.HideSelection = false;
            this.tvGameItems.Location = new System.Drawing.Point(2, 48);
            this.tvGameItems.Name = "tvGameItems";
            this.tvGameItems.Size = new System.Drawing.Size(224, 385);
            this.tvGameItems.TabIndex = 1;
            this.tvGameItems.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvGameItemsAfterCheck);
            this.tvGameItems.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TvGameItemsDrawNode);
            this.tvGameItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvItemsAfterSelect);
            this.tvGameItems.DoubleClick += new System.EventHandler(this.TvGameItemsDoubleClick);
            this.tvGameItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TvGameItemsMouseDown);
            this.tvGameItems.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TvGameItemsPreviewKeyDown);
            // 
            // pgItems
            // 
            this.pgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgItems.HelpVisible = false;
            this.pgItems.Location = new System.Drawing.Point(-1, 20);
            this.pgItems.Name = "pgItems";
            this.pgItems.Size = new System.Drawing.Size(412, 435);
            this.pgItems.TabIndex = 3;
            this.pgItems.ToolbarVisible = false;
            this.pgItems.Visible = false;
            this.pgItems.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PgItemsPropertyValueChanged);
            this.pgItems.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TvGameItemsPreviewKeyDown);
            // 
            // header1
            // 
            this.header1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.header1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.header1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.header1.Caption = "Selected item preferences";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Font = new System.Drawing.Font("Calibri", 9F);
            this.header1.ForeColor = System.Drawing.Color.Black;
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.header1.Size = new System.Drawing.Size(410, 21);
            this.header1.TabIndex = 4;
            this.header1.TabStop = false;
            this.header1.TopGradientColor = System.Drawing.Color.Lavender;
            // 
            // lblItemIsNotSelected
            // 
            this.lblItemIsNotSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemIsNotSelected.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemIsNotSelected.Location = new System.Drawing.Point(0, 0);
            this.lblItemIsNotSelected.Name = "lblItemIsNotSelected";
            this.lblItemIsNotSelected.Size = new System.Drawing.Size(410, 454);
            this.lblItemIsNotSelected.TabIndex = 5;
            this.lblItemIsNotSelected.Text = "Please select a group or a game item first";
            this.lblItemIsNotSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpIMS
            // 
            this.tpIMS.Controls.Add(this.pIMSBack);
            this.tpIMS.Location = new System.Drawing.Point(4, 23);
            this.tpIMS.Name = "tpIMS";
            this.tpIMS.Padding = new System.Windows.Forms.Padding(3);
            this.tpIMS.Size = new System.Drawing.Size(652, 462);
            this.tpIMS.TabIndex = 4;
            this.tpIMS.Text = "IMS";
            this.tpIMS.UseVisualStyleBackColor = true;
            // 
            // pIMSBack
            // 
            this.pIMSBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIMSBack.Controls.Add(this.tbIMS);
            this.pIMSBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pIMSBack.Location = new System.Drawing.Point(3, 3);
            this.pIMSBack.Name = "pIMSBack";
            this.pIMSBack.Size = new System.Drawing.Size(646, 456);
            this.pIMSBack.TabIndex = 3;
            // 
            // tbIMS
            // 
            this.tbIMS.BackColor = System.Drawing.Color.White;
            this.tbIMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbIMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIMS.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbIMS.Location = new System.Drawing.Point(0, 0);
            this.tbIMS.Multiline = true;
            this.tbIMS.Name = "tbIMS";
            this.tbIMS.ReadOnly = true;
            this.tbIMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbIMS.Size = new System.Drawing.Size(644, 454);
            this.tbIMS.TabIndex = 0;
            this.tbIMS.TabStop = false;
            // 
            // tpChat
            // 
            this.tpChat.Controls.Add(this.pChatBack);
            this.tpChat.Location = new System.Drawing.Point(4, 23);
            this.tpChat.Name = "tpChat";
            this.tpChat.Padding = new System.Windows.Forms.Padding(3);
            this.tpChat.Size = new System.Drawing.Size(652, 462);
            this.tpChat.TabIndex = 3;
            this.tpChat.Text = "Chat";
            this.tpChat.UseVisualStyleBackColor = true;
            // 
            // pChatBack
            // 
            this.pChatBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pChatBack.Controls.Add(this.tbChat);
            this.pChatBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pChatBack.Location = new System.Drawing.Point(3, 3);
            this.pChatBack.Name = "pChatBack";
            this.pChatBack.Size = new System.Drawing.Size(646, 456);
            this.pChatBack.TabIndex = 0;
            // 
            // tbChat
            // 
            this.tbChat.BackColor = System.Drawing.SystemColors.Window;
            this.tbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbChat.Location = new System.Drawing.Point(0, 0);
            this.tbChat.Name = "tbChat";
            this.tbChat.ReadOnly = true;
            this.tbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbChat.Size = new System.Drawing.Size(644, 454);
            this.tbChat.TabIndex = 1;
            this.tbChat.TabStop = false;
            this.tbChat.Text = "";
            // 
            // tpLogs
            // 
            this.tpLogs.Controls.Add(this.panel3);
            this.tpLogs.Controls.Add(this.tcLogs);
            this.tpLogs.Location = new System.Drawing.Point(4, 23);
            this.tpLogs.Name = "tpLogs";
            this.tpLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogs.Size = new System.Drawing.Size(652, 462);
            this.tpLogs.TabIndex = 1;
            this.tpLogs.Text = "Logs";
            this.tpLogs.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnClearLogs);
            this.panel3.Location = new System.Drawing.Point(624, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 23);
            this.panel3.TabIndex = 10;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.eraser;
            this.btnClearLogs.Location = new System.Drawing.Point(0, 0);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(24, 23);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.TabStop = false;
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.BtnClearLogsClick);
            // 
            // tcLogs
            // 
            this.tcLogs.Controls.Add(this.tpGeneralLogs);
            this.tcLogs.Controls.Add(this.tpActionsLogs);
            this.tcLogs.Controls.Add(this.tpDetailedLogs);
            this.tcLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLogs.Location = new System.Drawing.Point(3, 3);
            this.tcLogs.Name = "tcLogs";
            this.tcLogs.SelectedIndex = 0;
            this.tcLogs.Size = new System.Drawing.Size(646, 456);
            this.tcLogs.TabIndex = 0;
            // 
            // tpGeneralLogs
            // 
            this.tpGeneralLogs.Controls.Add(this.pGeneralLogsBack);
            this.tpGeneralLogs.Location = new System.Drawing.Point(4, 23);
            this.tpGeneralLogs.Name = "tpGeneralLogs";
            this.tpGeneralLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneralLogs.Size = new System.Drawing.Size(638, 429);
            this.tpGeneralLogs.TabIndex = 0;
            this.tpGeneralLogs.Text = "General";
            this.tpGeneralLogs.UseVisualStyleBackColor = true;
            // 
            // pGeneralLogsBack
            // 
            this.pGeneralLogsBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGeneralLogsBack.Controls.Add(this.tbGeneralLogs);
            this.pGeneralLogsBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGeneralLogsBack.Location = new System.Drawing.Point(3, 3);
            this.pGeneralLogsBack.Name = "pGeneralLogsBack";
            this.pGeneralLogsBack.Size = new System.Drawing.Size(632, 424);
            this.pGeneralLogsBack.TabIndex = 2;
            // 
            // tbGeneralLogs
            // 
            this.tbGeneralLogs.BackColor = System.Drawing.Color.White;
            this.tbGeneralLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbGeneralLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGeneralLogs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbGeneralLogs.Location = new System.Drawing.Point(0, 0);
            this.tbGeneralLogs.Multiline = true;
            this.tbGeneralLogs.Name = "tbGeneralLogs";
            this.tbGeneralLogs.ReadOnly = true;
            this.tbGeneralLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGeneralLogs.Size = new System.Drawing.Size(630, 422);
            this.tbGeneralLogs.TabIndex = 0;
            this.tbGeneralLogs.TabStop = false;
            // 
            // tpActionsLogs
            // 
            this.tpActionsLogs.Controls.Add(this.pActionsLogsBack);
            this.tpActionsLogs.Location = new System.Drawing.Point(4, 23);
            this.tpActionsLogs.Name = "tpActionsLogs";
            this.tpActionsLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tpActionsLogs.Size = new System.Drawing.Size(638, 429);
            this.tpActionsLogs.TabIndex = 2;
            this.tpActionsLogs.Text = "Actions";
            this.tpActionsLogs.UseVisualStyleBackColor = true;
            // 
            // pActionsLogsBack
            // 
            this.pActionsLogsBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pActionsLogsBack.Controls.Add(this.tbActionsLogs);
            this.pActionsLogsBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pActionsLogsBack.Location = new System.Drawing.Point(3, 3);
            this.pActionsLogsBack.Name = "pActionsLogsBack";
            this.pActionsLogsBack.Size = new System.Drawing.Size(632, 424);
            this.pActionsLogsBack.TabIndex = 3;
            // 
            // tbActionsLogs
            // 
            this.tbActionsLogs.BackColor = System.Drawing.Color.White;
            this.tbActionsLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbActionsLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActionsLogs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbActionsLogs.Location = new System.Drawing.Point(0, 0);
            this.tbActionsLogs.Multiline = true;
            this.tbActionsLogs.Name = "tbActionsLogs";
            this.tbActionsLogs.ReadOnly = true;
            this.tbActionsLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbActionsLogs.Size = new System.Drawing.Size(630, 422);
            this.tbActionsLogs.TabIndex = 1;
            this.tbActionsLogs.TabStop = false;
            // 
            // tpDetailedLogs
            // 
            this.tpDetailedLogs.Controls.Add(this.pDetailedLogsBack);
            this.tpDetailedLogs.Location = new System.Drawing.Point(4, 23);
            this.tpDetailedLogs.Name = "tpDetailedLogs";
            this.tpDetailedLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetailedLogs.Size = new System.Drawing.Size(638, 429);
            this.tpDetailedLogs.TabIndex = 1;
            this.tpDetailedLogs.Text = "Details";
            this.tpDetailedLogs.UseVisualStyleBackColor = true;
            // 
            // pDetailedLogsBack
            // 
            this.pDetailedLogsBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetailedLogsBack.Controls.Add(this.tbDetailedLogs);
            this.pDetailedLogsBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetailedLogsBack.Location = new System.Drawing.Point(3, 3);
            this.pDetailedLogsBack.Name = "pDetailedLogsBack";
            this.pDetailedLogsBack.Size = new System.Drawing.Size(632, 424);
            this.pDetailedLogsBack.TabIndex = 2;
            // 
            // tbDetailedLogs
            // 
            this.tbDetailedLogs.BackColor = System.Drawing.Color.White;
            this.tbDetailedLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDetailedLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetailedLogs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbDetailedLogs.Location = new System.Drawing.Point(0, 0);
            this.tbDetailedLogs.Multiline = true;
            this.tbDetailedLogs.Name = "tbDetailedLogs";
            this.tbDetailedLogs.ReadOnly = true;
            this.tbDetailedLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetailedLogs.Size = new System.Drawing.Size(630, 422);
            this.tbDetailedLogs.TabIndex = 1;
            this.tbDetailedLogs.TabStop = false;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect,
            this.toolStripSeparator2,
            this.btnOutInstantMessages,
            this.btnOutChatMessages,
            this.toolStripSeparator7,
            this.btnOutGeneralLogs,
            this.btnOutActionsLogs,
            this.btnOutDetailedLogs,
            this.toolStripSeparator5,
            this.btnRunGame,
            this.btnSettings});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(684, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = global::TimeZero.Auction.Bot.Properties.Resources.bullet_ball_glass_green;
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(23, 22);
            this.btnConnect.Text = "Connect [F5]";
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnect.Image = global::TimeZero.Auction.Bot.Properties.Resources.bullet_ball_glass_red;
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.btnDisconnect.Text = "Disconnect [F9]";
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnectClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOutInstantMessages
            // 
            this.btnOutInstantMessages.Checked = true;
            this.btnOutInstantMessages.CheckOnClick = true;
            this.btnOutInstantMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOutInstantMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutInstantMessages.Image = global::TimeZero.Auction.Bot.Properties.Resources.mail2;
            this.btnOutInstantMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutInstantMessages.Name = "btnOutInstantMessages";
            this.btnOutInstantMessages.Size = new System.Drawing.Size(23, 22);
            this.btnOutInstantMessages.Text = "Out instant messages";
            this.btnOutInstantMessages.Click += new System.EventHandler(this.BtnOutInstantMessagesClick);
            // 
            // btnOutChatMessages
            // 
            this.btnOutChatMessages.Checked = true;
            this.btnOutChatMessages.CheckOnClick = true;
            this.btnOutChatMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOutChatMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutChatMessages.Image = global::TimeZero.Auction.Bot.Properties.Resources.messages;
            this.btnOutChatMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutChatMessages.Name = "btnOutChatMessages";
            this.btnOutChatMessages.Size = new System.Drawing.Size(23, 22);
            this.btnOutChatMessages.Text = "Out chat messages";
            this.btnOutChatMessages.Click += new System.EventHandler(this.BtnOutChatMessagesClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOutGeneralLogs
            // 
            this.btnOutGeneralLogs.Checked = true;
            this.btnOutGeneralLogs.CheckOnClick = true;
            this.btnOutGeneralLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOutGeneralLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutGeneralLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.document_text;
            this.btnOutGeneralLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutGeneralLogs.Name = "btnOutGeneralLogs";
            this.btnOutGeneralLogs.Size = new System.Drawing.Size(23, 22);
            this.btnOutGeneralLogs.Text = "Out general logs";
            this.btnOutGeneralLogs.Click += new System.EventHandler(this.BtnOutGeneralLogsClick);
            // 
            // btnOutActionsLogs
            // 
            this.btnOutActionsLogs.CheckOnClick = true;
            this.btnOutActionsLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutActionsLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.document_gear;
            this.btnOutActionsLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutActionsLogs.Name = "btnOutActionsLogs";
            this.btnOutActionsLogs.Size = new System.Drawing.Size(23, 22);
            this.btnOutActionsLogs.Text = "Out actions logs";
            this.btnOutActionsLogs.Click += new System.EventHandler(this.BtnOutActionsLogsClick);
            // 
            // btnOutDetailedLogs
            // 
            this.btnOutDetailedLogs.CheckOnClick = true;
            this.btnOutDetailedLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutDetailedLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.document;
            this.btnOutDetailedLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutDetailedLogs.Name = "btnOutDetailedLogs";
            this.btnOutDetailedLogs.Size = new System.Drawing.Size(23, 22);
            this.btnOutDetailedLogs.Text = "Out detailed logs";
            this.btnOutDetailedLogs.Click += new System.EventHandler(this.BtnOutDetailedLogsClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRunGame
            // 
            this.btnRunGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRunGame.Image = global::TimeZero.Auction.Bot.Properties.Resources.tz;
            this.btnRunGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunGame.Name = "btnRunGame";
            this.btnRunGame.Size = new System.Drawing.Size(23, 22);
            this.btnRunGame.Text = "Run the game";
            this.btnRunGame.Click += new System.EventHandler(this.BtnRunGameClick);
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = global::TimeZero.Auction.Bot.Properties.Resources.wrench;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // flashPlayer
            // 
            this.flashPlayer.Enabled = true;
            this.flashPlayer.Location = new System.Drawing.Point(-1, -1);
            this.flashPlayer.Name = "flashPlayer";
            this.flashPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashPlayer.OcxState")));
            this.flashPlayer.Size = new System.Drawing.Size(0, 0);
            this.flashPlayer.TabIndex = 4;
            this.flashPlayer.TabStop = false;
            this.flashPlayer.Visible = false;
            // 
            // timerReconnect
            // 
            this.timerReconnect.Interval = 300000;
            this.timerReconnect.Tick += new System.EventHandler(this.TimerReconnectTick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 7342);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slNetworkOut,
            this.slNetworkIn,
            this.toolStripStatusLabel2,
            this.lblActionInProgress});
            this.ssMain.Location = new System.Drawing.Point(0, 525);
            this.ssMain.Name = "ssMain";
            this.ssMain.ShowItemToolTips = true;
            this.ssMain.Size = new System.Drawing.Size(684, 22);
            this.ssMain.TabIndex = 5;
            // 
            // slNetworkOut
            // 
            this.slNetworkOut.Image = global::TimeZero.Auction.Bot.Properties.Resources.server_from_client_grayed;
            this.slNetworkOut.Name = "slNetworkOut";
            this.slNetworkOut.Size = new System.Drawing.Size(16, 17);
            this.slNetworkOut.ToolTipText = "0 bytes sended";
            // 
            // slNetworkIn
            // 
            this.slNetworkIn.Image = global::TimeZero.Auction.Bot.Properties.Resources.server_to_client_grayed;
            this.slNetworkIn.Name = "slNetworkIn";
            this.slNetworkIn.Size = new System.Drawing.Size(16, 17);
            this.slNetworkIn.ToolTipText = "0 bytes received";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel2.Text = "  Current action:";
            // 
            // lblActionInProgress
            // 
            this.lblActionInProgress.Name = "lblActionInProgress";
            this.lblActionInProgress.Size = new System.Drawing.Size(22, 17);
            this.lblActionInProgress.Text = "---";
            // 
            // timerNetworkActivity
            // 
            this.timerNetworkActivity.Enabled = true;
            this.timerNetworkActivity.Tick += new System.EventHandler(this.TimerNetworkActivityTick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(36, 527);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 19);
            this.panel2.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 547);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.flashPlayer);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 585);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeZero Auction Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMainKeyDown);
            this.tcMain.ResumeLayout(false);
            this.tpItems.ResumeLayout(false);
            this.scItems.Panel1.ResumeLayout(false);
            this.scItems.Panel2.ResumeLayout(false);
            this.scItems.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tsGameItems.ResumeLayout(false);
            this.tsGameItems.PerformLayout();
            this.tpIMS.ResumeLayout(false);
            this.pIMSBack.ResumeLayout(false);
            this.pIMSBack.PerformLayout();
            this.tpChat.ResumeLayout(false);
            this.pChatBack.ResumeLayout(false);
            this.tpLogs.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tcLogs.ResumeLayout(false);
            this.tpGeneralLogs.ResumeLayout(false);
            this.pGeneralLogsBack.ResumeLayout(false);
            this.pGeneralLogsBack.PerformLayout();
            this.tpActionsLogs.ResumeLayout(false);
            this.pActionsLogsBack.ResumeLayout(false);
            this.pActionsLogsBack.PerformLayout();
            this.tpDetailedLogs.ResumeLayout(false);
            this.pDetailedLogsBack.ResumeLayout(false);
            this.pDetailedLogsBack.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayer)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tpLogs;
        private AxShockwaveFlashObjects.AxShockwaveFlash flashPlayer;
        private System.Windows.Forms.TabPage tpItems;
        private System.Windows.Forms.SplitContainer scItems;
        private TreeViewSearchBox tvsbItems;
        private System.Windows.Forms.TreeView tvGameItems;
        private Header hAttributesList;
        private Header header1;
        private PropertyGrid pgItems;
        private System.Windows.Forms.Label lblItemIsNotSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsGameItems;
        private System.Windows.Forms.ToolStripButton btnGameItemsSetDefaults;
        private System.Windows.Forms.ToolStripButton btnGameItemsRefresh;
        private System.Windows.Forms.ToolStripButton btnGameItemsSaveAll;
        private System.Windows.Forms.Timer timerReconnect;
        private System.Windows.Forms.ToolStripButton btnGameItemRemove;
        private System.Windows.Forms.ToolStripButton btnGameItemsOrderSubGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnGameItemsJumpToUnreviewed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnOutGeneralLogs;
        private ToolStripButton btnOutDetailedLogs;
        private StatusStrip ssMain;
        private ToolStripStatusLabel slNetworkOut;
        private ToolStripStatusLabel slNetworkIn;
        private Timer timerNetworkActivity;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnRunGame;
        private Panel panel2;
        private ToolStripButton btnGameItemsMultiSelect;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblActionInProgress;
        private ToolStripButton btnSettings;
        private ToolStripDropDownButton btnGameItemsActions;
        private ToolStripMenuItem removeAllUnreviewedItemsToolStripMenuItem;
        private ToolStripMenuItem removeAllZerocostItemsToolStripMenuItem;
        private TabControl tcLogs;
        private TabPage tpGeneralLogs;
        private Panel pGeneralLogsBack;
        private TextBox tbGeneralLogs;
        private TabPage tpDetailedLogs;
        private Panel pDetailedLogsBack;
        private TextBox tbDetailedLogs;
        private TabPage tpActionsLogs;
        private Panel pActionsLogsBack;
        private TextBox tbActionsLogs;
        private ToolStripButton btnOutActionsLogs;
        private Panel panel3;
        private Button btnClearLogs;
        private TabPage tpChat;
        private Panel pChatBack;
        private RichTextBox tbChat;
        private TabPage tpIMS;
        private Panel pIMSBack;
        private TextBox tbIMS;
        private ToolStripButton btnOutInstantMessages;
        private ToolStripButton btnOutChatMessages;
        private ToolStripSeparator toolStripSeparator7;
    }
}

