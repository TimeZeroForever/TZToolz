namespace TimeZero.Auction.Bot.Forms
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("General", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Main window", 1);
            this.ilHelp = new System.Windows.Forms.ImageList(this.components);
            this.pSettings = new System.Windows.Forms.Panel();
            this.tbSettings = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tbGamePort = new System.Windows.Forms.TextBox();
            this.btnBrowseGameFolder = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGameFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbClientVer2 = new System.Windows.Forms.TextBox();
            this.lblClientVer2 = new System.Windows.Forms.Label();
            this.tbClientVer1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGameServer = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblServerSettings = new System.Windows.Forms.Label();
            this.chkSendHotkeyAfterSubmit = new System.Windows.Forms.CheckBox();
            this.tpMainWindow = new System.Windows.Forms.TabPage();
            this.cbOutDetailedLogInfo = new System.Windows.Forms.CheckBox();
            this.cbOutLogInfo = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.fbdGameFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ilSettings = new System.Windows.Forms.ImageList(this.components);
            this.lvSettings = new TimeZero.Auction.Bot.Controls.SettingsListView.SettingsListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pSettings.SuspendLayout();
            this.tbSettings.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpMainWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilHelp
            // 
            this.ilHelp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilHelp.ImageStream")));
            this.ilHelp.TransparentColor = System.Drawing.Color.Transparent;
            this.ilHelp.Images.SetKeyName(0, "help.png");
            // 
            // pSettings
            // 
            this.pSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pSettings.BackColor = System.Drawing.Color.White;
            this.pSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSettings.Controls.Add(this.tbSettings);
            this.pSettings.Location = new System.Drawing.Point(194, 13);
            this.pSettings.Name = "pSettings";
            this.pSettings.Size = new System.Drawing.Size(373, 381);
            this.pSettings.TabIndex = 3;
            // 
            // tbSettings
            // 
            this.tbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSettings.Controls.Add(this.tpGeneral);
            this.tbSettings.Controls.Add(this.tpMainWindow);
            this.tbSettings.Location = new System.Drawing.Point(-1, -1);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.SelectedIndex = 0;
            this.tbSettings.Size = new System.Drawing.Size(376, 382);
            this.tbSettings.TabIndex = 2;
            this.tbSettings.TabStop = false;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.tbGamePort);
            this.tpGeneral.Controls.Add(this.btnBrowseGameFolder);
            this.tpGeneral.Controls.Add(this.tbPassword);
            this.tpGeneral.Controls.Add(this.label9);
            this.tpGeneral.Controls.Add(this.tbLogin);
            this.tpGeneral.Controls.Add(this.label8);
            this.tpGeneral.Controls.Add(this.panel2);
            this.tpGeneral.Controls.Add(this.label7);
            this.tpGeneral.Controls.Add(this.tbGameFolder);
            this.tpGeneral.Controls.Add(this.label6);
            this.tpGeneral.Controls.Add(this.tbClientVer2);
            this.tpGeneral.Controls.Add(this.lblClientVer2);
            this.tpGeneral.Controls.Add(this.tbClientVer1);
            this.tpGeneral.Controls.Add(this.label3);
            this.tpGeneral.Controls.Add(this.panel1);
            this.tpGeneral.Controls.Add(this.label1);
            this.tpGeneral.Controls.Add(this.label4);
            this.tpGeneral.Controls.Add(this.label2);
            this.tpGeneral.Controls.Add(this.tbGameServer);
            this.tpGeneral.Controls.Add(this.panel5);
            this.tpGeneral.Controls.Add(this.lblServerSettings);
            this.tpGeneral.Controls.Add(this.chkSendHotkeyAfterSubmit);
            this.tpGeneral.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tpGeneral.Location = new System.Drawing.Point(4, 24);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(368, 354);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tbGamePort
            // 
            this.tbGamePort.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGamePort.Location = new System.Drawing.Point(318, 28);
            this.tbGamePort.MaxLength = 5;
            this.tbGamePort.Name = "tbGamePort";
            this.tbGamePort.Size = new System.Drawing.Size(39, 22);
            this.tbGamePort.TabIndex = 95;
            // 
            // btnBrowseGameFolder
            // 
            this.btnBrowseGameFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseGameFolder.Image = global::TimeZero.Auction.Bot.Properties.Resources.folder_explore;
            this.btnBrowseGameFolder.Location = new System.Drawing.Point(332, 110);
            this.btnBrowseGameFolder.Name = "btnBrowseGameFolder";
            this.btnBrowseGameFolder.Size = new System.Drawing.Size(26, 23);
            this.btnBrowseGameFolder.TabIndex = 110;
            this.btnBrowseGameFolder.TabStop = false;
            this.btnBrowseGameFolder.UseVisualStyleBackColor = true;
            this.btnBrowseGameFolder.Click += new System.EventHandler(this.BtnBrowseGameFolderClick);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(114, 194);
            this.tbPassword.MaxLength = 50;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(243, 22);
            this.tbPassword.TabIndex = 109;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 108;
            this.label9.Text = "Password:";
            // 
            // tbLogin
            // 
            this.tbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.Location = new System.Drawing.Point(114, 166);
            this.tbLogin.MaxLength = 16;
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(243, 22);
            this.tbLogin.TabIndex = 107;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 106;
            this.label8.Text = "Game login:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(7, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(3, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 15);
            this.label7.TabIndex = 104;
            this.label7.Text = "Login information";
            // 
            // tbGameFolder
            // 
            this.tbGameFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameFolder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGameFolder.Location = new System.Drawing.Point(114, 111);
            this.tbGameFolder.MaxLength = 500;
            this.tbGameFolder.Name = "tbGameFolder";
            this.tbGameFolder.Size = new System.Drawing.Size(217, 22);
            this.tbGameFolder.TabIndex = 103;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 102;
            this.label6.Text = "Game folder:";
            // 
            // tbClientVer2
            // 
            this.tbClientVer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClientVer2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbClientVer2.Location = new System.Drawing.Point(267, 83);
            this.tbClientVer2.MaxLength = 20;
            this.tbClientVer2.Name = "tbClientVer2";
            this.tbClientVer2.Size = new System.Drawing.Size(90, 22);
            this.tbClientVer2.TabIndex = 101;
            // 
            // lblClientVer2
            // 
            this.lblClientVer2.AutoSize = true;
            this.lblClientVer2.Location = new System.Drawing.Point(166, 85);
            this.lblClientVer2.Name = "lblClientVer2";
            this.lblClientVer2.Size = new System.Drawing.Size(95, 15);
            this.lblClientVer2.TabIndex = 100;
            this.lblClientVer2.Text = "client version 2:";
            // 
            // tbClientVer1
            // 
            this.tbClientVer1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbClientVer1.Location = new System.Drawing.Point(114, 83);
            this.tbClientVer1.MaxLength = 3;
            this.tbClientVer1.Name = "tbClientVer1";
            this.tbClientVer1.Size = new System.Drawing.Size(46, 22);
            this.tbClientVer1.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 98;
            this.label3.Text = "Client version 1:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 1);
            this.panel1.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(3, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Client settings";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 94;
            this.label4.Text = "port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "Game server IP:";
            // 
            // tbGameServer
            // 
            this.tbGameServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameServer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGameServer.Location = new System.Drawing.Point(114, 28);
            this.tbGameServer.MaxLength = 15;
            this.tbGameServer.Name = "tbGameServer";
            this.tbGameServer.Size = new System.Drawing.Size(159, 22);
            this.tbGameServer.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(7, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 1);
            this.panel5.TabIndex = 87;
            // 
            // lblServerSettings
            // 
            this.lblServerSettings.AutoSize = true;
            this.lblServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblServerSettings.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblServerSettings.Location = new System.Drawing.Point(3, 3);
            this.lblServerSettings.Name = "lblServerSettings";
            this.lblServerSettings.Size = new System.Drawing.Size(88, 15);
            this.lblServerSettings.TabIndex = 86;
            this.lblServerSettings.Text = "Server settings";
            // 
            // chkSendHotkeyAfterSubmit
            // 
            this.chkSendHotkeyAfterSubmit.AutoSize = true;
            this.chkSendHotkeyAfterSubmit.BackColor = System.Drawing.Color.Transparent;
            this.chkSendHotkeyAfterSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSendHotkeyAfterSubmit.Location = new System.Drawing.Point(3, 373);
            this.chkSendHotkeyAfterSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.chkSendHotkeyAfterSubmit.Name = "chkSendHotkeyAfterSubmit";
            this.chkSendHotkeyAfterSubmit.Size = new System.Drawing.Size(175, 19);
            this.chkSendHotkeyAfterSubmit.TabIndex = 85;
            this.chkSendHotkeyAfterSubmit.TabStop = false;
            this.chkSendHotkeyAfterSubmit.Tag = "";
            this.chkSendHotkeyAfterSubmit.Text = "Send hotkey after submition";
            this.chkSendHotkeyAfterSubmit.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSendHotkeyAfterSubmit.UseVisualStyleBackColor = false;
            this.chkSendHotkeyAfterSubmit.Visible = false;
            // 
            // tpMainWindow
            // 
            this.tpMainWindow.Controls.Add(this.cbOutDetailedLogInfo);
            this.tpMainWindow.Controls.Add(this.cbOutLogInfo);
            this.tpMainWindow.Controls.Add(this.panel3);
            this.tpMainWindow.Controls.Add(this.label5);
            this.tpMainWindow.Location = new System.Drawing.Point(4, 24);
            this.tpMainWindow.Name = "tpMainWindow";
            this.tpMainWindow.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainWindow.Size = new System.Drawing.Size(368, 354);
            this.tpMainWindow.TabIndex = 2;
            this.tpMainWindow.Text = "Main window";
            this.tpMainWindow.UseVisualStyleBackColor = true;
            // 
            // cbOutDetailedLogInfo
            // 
            this.cbOutDetailedLogInfo.AutoSize = true;
            this.cbOutDetailedLogInfo.Location = new System.Drawing.Point(15, 53);
            this.cbOutDetailedLogInfo.Name = "cbOutDetailedLogInfo";
            this.cbOutDetailedLogInfo.Size = new System.Drawing.Size(154, 17);
            this.cbOutDetailedLogInfo.TabIndex = 91;
            this.cbOutDetailedLogInfo.Text = "Out detailed log information";
            this.cbOutDetailedLogInfo.UseVisualStyleBackColor = true;
            // 
            // cbOutLogInfo
            // 
            this.cbOutLogInfo.AutoSize = true;
            this.cbOutLogInfo.Location = new System.Drawing.Point(15, 30);
            this.cbOutLogInfo.Name = "cbOutLogInfo";
            this.cbOutLogInfo.Size = new System.Drawing.Size(114, 17);
            this.cbOutLogInfo.TabIndex = 90;
            this.cbOutLogInfo.Text = "Out log information";
            this.cbOutLogInfo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(7, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 1);
            this.panel3.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 88;
            this.label5.Text = "Logging";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(482, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.Location = new System.Drawing.Point(387, 404);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 24);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Save settings";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApplyClick);
            // 
            // fbdGameFolder
            // 
            this.fbdGameFolder.Description = "Please select TimeZero game folder. Some of the game resources will be used to ma" +
    "ke authorization on a game server.";
            this.fbdGameFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdGameFolder.ShowNewFolderButton = false;
            // 
            // ilSettings
            // 
            this.ilSettings.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSettings.ImageStream")));
            this.ilSettings.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSettings.Images.SetKeyName(0, "wrench.png");
            this.ilSettings.Images.SetKeyName(1, "text_rich_marked.png");
            this.ilSettings.Images.SetKeyName(2, "text_tree.png");
            this.ilSettings.Images.SetKeyName(3, "window_edit.png");
            this.ilSettings.Images.SetKeyName(4, "star_blue.png");
            // 
            // lvSettings
            // 
            this.lvSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSettings.FullRowSelect = true;
            this.lvSettings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSettings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvSettings.Location = new System.Drawing.Point(14, 13);
            this.lvSettings.MultiSelect = false;
            this.lvSettings.Name = "lvSettings";
            this.lvSettings.OwnerDraw = true;
            this.lvSettings.Scrollable = false;
            this.lvSettings.Size = new System.Drawing.Size(174, 381);
            this.lvSettings.SmallImageList = this.ilSettings;
            this.lvSettings.TabIndex = 4;
            this.lvSettings.UseCompatibleStateImageBehavior = false;
            this.lvSettings.View = System.Windows.Forms.View.Details;
            this.lvSettings.SelectedIndexChanged += new System.EventHandler(this.LvSettingsSelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Settings";
            this.columnHeader1.Width = 500;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 439);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lvSettings);
            this.Controls.Add(this.pSettings);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSettingsKeyDown);
            this.pSettings.ResumeLayout(false);
            this.tbSettings.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpMainWindow.ResumeLayout(false);
            this.tpMainWindow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilHelp;
        private System.Windows.Forms.Panel pSettings;
        public System.Windows.Forms.TabControl tbSettings;
        private System.Windows.Forms.TabPage tpGeneral;
        public System.Windows.Forms.TextBox tbGameServer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblServerSettings;
        public System.Windows.Forms.CheckBox chkSendHotkeyAfterSubmit;
        private Controls.SettingsListView.SettingsListView lvSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbClientVer2;
        private System.Windows.Forms.Label lblClientVer2;
        public System.Windows.Forms.TextBox tbClientVer1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbGameFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBrowseGameFolder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.FolderBrowserDialog fbdGameFolder;
        private System.Windows.Forms.ImageList ilSettings;
        private System.Windows.Forms.TabPage tpMainWindow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbOutLogInfo;
        private System.Windows.Forms.CheckBox cbOutDetailedLogInfo;
        public System.Windows.Forms.TextBox tbGamePort;
    }
}