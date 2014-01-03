namespace TimeZero.Auction.Bot.Controls.TreeViewSearchBox
{
    partial class TreeViewSearchBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewSearchBox));
            this.pSearch = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            this.SuspendLayout();
            // 
            // pSearch
            // 
            this.pSearch.BackColor = System.Drawing.SystemColors.Window;
            this.pSearch.Controls.Add(this.tbSearch);
            this.pSearch.Controls.Add(this.btnClear);
            this.pSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSearch.Location = new System.Drawing.Point(1, 1);
            this.pSearch.Name = "pSearch";
            this.pSearch.Size = new System.Drawing.Size(108, 18);
            this.pSearch.TabIndex = 7;
            this.pSearch.MouseLeave += new System.EventHandler(this.TreeViewSearchBoxMouseLeave);
            this.pSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewSearchBoxMouseDown);
            this.pSearch.MouseEnter += new System.EventHandler(this.TreeViewSearchBoxMouseEnter);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearch.Location = new System.Drawing.Point(2, 2);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(90, 14);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearchTextChanged);
            this.tbSearch.MouseLeave += new System.EventHandler(this.TreeViewSearchBoxMouseLeave);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSearchKeyDown);
            this.tbSearch.Leave += new System.EventHandler(this.TbSearchLeave);
            this.tbSearch.Enter += new System.EventHandler(this.TbSearchEnter);
            this.tbSearch.MouseEnter += new System.EventHandler(this.TreeViewSearchBoxMouseEnter);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(91, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(16, 16);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClear.TabIndex = 2;
            this.btnClear.TabStop = false;
            this.btnClear.MouseLeave += new System.EventHandler(this.TreeViewSearchBoxMouseLeave);
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            this.btnClear.Paint += new System.Windows.Forms.PaintEventHandler(this.BtnClearPaint);
            this.btnClear.MouseEnter += new System.EventHandler(this.TreeViewSearchBoxMouseEnter);
            // 
            // TreeViewSearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pSearch);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name = "TreeViewSearchBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(110, 20);
            this.MouseLeave += new System.EventHandler(this.TreeViewSearchBoxMouseLeave);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TreeViewSearchBoxPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewSearchBoxMouseDown);
            this.MouseEnter += new System.EventHandler(this.TreeViewSearchBoxMouseEnter);
            this.pSearch.ResumeLayout(false);
            this.pSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSearch;
        public System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.PictureBox btnClear;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
