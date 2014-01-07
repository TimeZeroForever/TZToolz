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
            this.tvGameItems = new System.Windows.Forms.TreeView();
            this.pgItems = new System.Windows.Forms.PropertyGrid();
            this.lblItemIsNotSelected = new System.Windows.Forms.Label();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.pLogInfoBack = new System.Windows.Forms.Panel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tpDetailedLog = new System.Windows.Forms.TabPage();
            this.pDetailedLogBack = new System.Windows.Forms.Panel();
            this.tbDetailedLog = new System.Windows.Forms.TextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOutLogs = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastShoppingTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblActionInProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerNetworkActivity = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.hAttributesList = new TimeZero.Auction.Bot.Controls.Header.Header();
            this.tvsbItems = new TimeZero.Auction.Bot.Controls.TreeViewSearchBox.TreeViewSearchBox();
            this.header1 = new TimeZero.Auction.Bot.Controls.Header.Header();
            this.tcMain.SuspendLayout();
            this.tpItems.SuspendLayout();
            this.scItems.Panel1.SuspendLayout();
            this.scItems.Panel2.SuspendLayout();
            this.scItems.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsGameItems.SuspendLayout();
            this.tpLog.SuspendLayout();
            this.pLogInfoBack.SuspendLayout();
            this.tpDetailedLog.SuspendLayout();
            this.pDetailedLogBack.SuspendLayout();
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
            this.tcMain.Controls.Add(this.tpLog);
            this.tcMain.Controls.Add(this.tpDetailedLog);
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
            this.removeAllUnreviewedItemsToolStripMenuItem.Click += new System.EventHandler(this.removeAllUnreviewedItemsToolStripMenuItem_Click);
            // 
            // removeAllZerocostItemsToolStripMenuItem
            // 
            this.removeAllZerocostItemsToolStripMenuItem.Name = "removeAllZerocostItemsToolStripMenuItem";
            this.removeAllZerocostItemsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeAllZerocostItemsToolStripMenuItem.Text = "Remove all zero-cost items";
            this.removeAllZerocostItemsToolStripMenuItem.Click += new System.EventHandler(this.removeAllZerocostItemsToolStripMenuItem_Click);
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
            // tpLog
            // 
            this.tpLog.Controls.Add(this.pLogInfoBack);
            this.tpLog.Location = new System.Drawing.Point(4, 23);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpLog.Size = new System.Drawing.Size(652, 462);
            this.tpLog.TabIndex = 1;
            this.tpLog.Text = "Log information";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // pLogInfoBack
            // 
            this.pLogInfoBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLogInfoBack.Controls.Add(this.tbLog);
            this.pLogInfoBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLogInfoBack.Location = new System.Drawing.Point(3, 3);
            this.pLogInfoBack.Name = "pLogInfoBack";
            this.pLogInfoBack.Size = new System.Drawing.Size(646, 457);
            this.pLogInfoBack.TabIndex = 0;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(644, 455);
            this.tbLog.TabIndex = 0;
            this.tbLog.TabStop = false;
            // 
            // tpDetailedLog
            // 
            this.tpDetailedLog.Controls.Add(this.pDetailedLogBack);
            this.tpDetailedLog.Location = new System.Drawing.Point(4, 23);
            this.tpDetailedLog.Name = "tpDetailedLog";
            this.tpDetailedLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetailedLog.Size = new System.Drawing.Size(652, 462);
            this.tpDetailedLog.TabIndex = 0;
            this.tpDetailedLog.Text = "Detailed log information";
            this.tpDetailedLog.UseVisualStyleBackColor = true;
            // 
            // pDetailedLogBack
            // 
            this.pDetailedLogBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetailedLogBack.Controls.Add(this.tbDetailedLog);
            this.pDetailedLogBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetailedLogBack.Location = new System.Drawing.Point(3, 3);
            this.pDetailedLogBack.Name = "pDetailedLogBack";
            this.pDetailedLogBack.Size = new System.Drawing.Size(646, 457);
            this.pDetailedLogBack.TabIndex = 1;
            // 
            // tbDetailedLog
            // 
            this.tbDetailedLog.BackColor = System.Drawing.Color.White;
            this.tbDetailedLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDetailedLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetailedLog.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbDetailedLog.Location = new System.Drawing.Point(0, 0);
            this.tbDetailedLog.Multiline = true;
            this.tbDetailedLog.Name = "tbDetailedLog";
            this.tbDetailedLog.ReadOnly = true;
            this.tbDetailedLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetailedLog.Size = new System.Drawing.Size(644, 455);
            this.tbDetailedLog.TabIndex = 1;
            this.tbDetailedLog.TabStop = false;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect,
            this.toolStripSeparator2,
            this.btnOutLogs,
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
            // btnOutLogs
            // 
            this.btnOutLogs.Checked = true;
            this.btnOutLogs.CheckOnClick = true;
            this.btnOutLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOutLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.document_text;
            this.btnOutLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutLogs.Name = "btnOutLogs";
            this.btnOutLogs.Size = new System.Drawing.Size(23, 22);
            this.btnOutLogs.Text = "Out log information";
            this.btnOutLogs.Click += new System.EventHandler(this.BtnOutLogsClick);
            // 
            // btnOutDetailedLogs
            // 
            this.btnOutDetailedLogs.CheckOnClick = true;
            this.btnOutDetailedLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutDetailedLogs.Image = global::TimeZero.Auction.Bot.Properties.Resources.document;
            this.btnOutDetailedLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutDetailedLogs.Name = "btnOutDetailedLogs";
            this.btnOutDetailedLogs.Size = new System.Drawing.Size(23, 22);
            this.btnOutDetailedLogs.Text = "toolStripButton2";
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
            this.toolStripStatusLabel1,
            this.lblLastShoppingTime,
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
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(138, 17);
            this.toolStripStatusLabel1.Text = "  Last shopping duration:";
            // 
            // lblLastShoppingTime
            // 
            this.lblLastShoppingTime.Name = "lblLastShoppingTime";
            this.lblLastShoppingTime.Size = new System.Drawing.Size(22, 17);
            this.lblLastShoppingTime.Text = "---";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel2.Text = "Current action:";
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
            this.tpLog.ResumeLayout(false);
            this.pLogInfoBack.ResumeLayout(false);
            this.pLogInfoBack.PerformLayout();
            this.tpDetailedLog.ResumeLayout(false);
            this.pDetailedLogBack.ResumeLayout(false);
            this.pDetailedLogBack.PerformLayout();
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
        private System.Windows.Forms.TabPage tpDetailedLog;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tpLog;
        private System.Windows.Forms.Panel pLogInfoBack;
        private System.Windows.Forms.Panel pDetailedLogBack;
        private AxShockwaveFlashObjects.AxShockwaveFlash flashPlayer;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbDetailedLog;
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
        private ToolStripButton btnOutLogs;
        private ToolStripButton btnOutDetailedLogs;
        private StatusStrip ssMain;
        private ToolStripStatusLabel slNetworkOut;
        private ToolStripStatusLabel slNetworkIn;
        private Timer timerNetworkActivity;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnRunGame;
        private Panel panel2;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblLastShoppingTime;
        private ToolStripButton btnGameItemsMultiSelect;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblActionInProgress;
        private ToolStripButton btnSettings;
        private ToolStripDropDownButton btnGameItemsActions;
        private ToolStripMenuItem removeAllUnreviewedItemsToolStripMenuItem;
        private ToolStripMenuItem removeAllZerocostItemsToolStripMenuItem;
    }
}

