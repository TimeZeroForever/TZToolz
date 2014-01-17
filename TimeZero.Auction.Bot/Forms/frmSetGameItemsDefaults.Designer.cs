namespace TimeZero.Auction.Bot.Forms
{
    partial class frmSetGameItemsDefaults
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
            this.pSubGroups = new System.Windows.Forms.Panel();
            this.cbUseSubGroupsIgnoreForSelling = new System.Windows.Forms.CheckBox();
            this.cbSubGroupsIgnoreForSelling = new System.Windows.Forms.CheckBox();
            this.cbUseSubGroupsUseExtendedShoppingRule = new System.Windows.Forms.CheckBox();
            this.cbUseSubGroupsShopPagesLimit = new System.Windows.Forms.CheckBox();
            this.cbUseSubGroupsIgnoreForShopping = new System.Windows.Forms.CheckBox();
            this.cbSubGroupsUseExtendedShoppingRule = new System.Windows.Forms.CheckBox();
            this.cbSubGroupsIgnoreForShopping = new System.Windows.Forms.CheckBox();
            this.tbSubGroupsShopPagesLimit = new System.Windows.Forms.NumericUpDown();
            this.pGameItems = new System.Windows.Forms.Panel();
            this.cbGameItemsUseInstantCostIfNoPublicCost = new System.Windows.Forms.CheckBox();
            this.tbGameItemsInstantPurchasePerz = new System.Windows.Forms.NumericUpDown();
            this.rbGameItemsInstantPurchasePerz = new System.Windows.Forms.RadioButton();
            this.rbGameItemsInstantPurchaseCost = new System.Windows.Forms.RadioButton();
            this.tbGameItemsInstantPurchaseCost = new System.Windows.Forms.NumericUpDown();
            this.cbGameItems = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pSubGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubGroupsShopPagesLimit)).BeginInit();
            this.pGameItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGameItemsInstantPurchasePerz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGameItemsInstantPurchaseCost)).BeginInit();
            this.SuspendLayout();
            // 
            // pSubGroups
            // 
            this.pSubGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pSubGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSubGroups.Controls.Add(this.cbUseSubGroupsIgnoreForSelling);
            this.pSubGroups.Controls.Add(this.cbSubGroupsIgnoreForSelling);
            this.pSubGroups.Controls.Add(this.cbUseSubGroupsUseExtendedShoppingRule);
            this.pSubGroups.Controls.Add(this.cbUseSubGroupsShopPagesLimit);
            this.pSubGroups.Controls.Add(this.cbUseSubGroupsIgnoreForShopping);
            this.pSubGroups.Controls.Add(this.cbSubGroupsUseExtendedShoppingRule);
            this.pSubGroups.Controls.Add(this.cbSubGroupsIgnoreForShopping);
            this.pSubGroups.Controls.Add(this.tbSubGroupsShopPagesLimit);
            this.pSubGroups.Location = new System.Drawing.Point(12, 12);
            this.pSubGroups.Name = "pSubGroups";
            this.pSubGroups.Size = new System.Drawing.Size(241, 125);
            this.pSubGroups.TabIndex = 1;
            // 
            // cbUseSubGroupsIgnoreForSelling
            // 
            this.cbUseSubGroupsIgnoreForSelling.AutoSize = true;
            this.cbUseSubGroupsIgnoreForSelling.Location = new System.Drawing.Point(15, 42);
            this.cbUseSubGroupsIgnoreForSelling.Name = "cbUseSubGroupsIgnoreForSelling";
            this.cbUseSubGroupsIgnoreForSelling.Size = new System.Drawing.Size(15, 14);
            this.cbUseSubGroupsIgnoreForSelling.TabIndex = 6;
            this.cbUseSubGroupsIgnoreForSelling.UseVisualStyleBackColor = true;
            this.cbUseSubGroupsIgnoreForSelling.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbSubGroupsIgnoreForSelling
            // 
            this.cbSubGroupsIgnoreForSelling.AutoSize = true;
            this.cbSubGroupsIgnoreForSelling.Location = new System.Drawing.Point(38, 40);
            this.cbSubGroupsIgnoreForSelling.Name = "cbSubGroupsIgnoreForSelling";
            this.cbSubGroupsIgnoreForSelling.Size = new System.Drawing.Size(120, 18);
            this.cbSubGroupsIgnoreForSelling.TabIndex = 7;
            this.cbSubGroupsIgnoreForSelling.Text = "Ignore for selling";
            this.cbSubGroupsIgnoreForSelling.UseVisualStyleBackColor = true;
            this.cbSubGroupsIgnoreForSelling.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbUseSubGroupsUseExtendedShoppingRule
            // 
            this.cbUseSubGroupsUseExtendedShoppingRule.AutoSize = true;
            this.cbUseSubGroupsUseExtendedShoppingRule.Location = new System.Drawing.Point(15, 67);
            this.cbUseSubGroupsUseExtendedShoppingRule.Name = "cbUseSubGroupsUseExtendedShoppingRule";
            this.cbUseSubGroupsUseExtendedShoppingRule.Size = new System.Drawing.Size(15, 14);
            this.cbUseSubGroupsUseExtendedShoppingRule.TabIndex = 2;
            this.cbUseSubGroupsUseExtendedShoppingRule.UseVisualStyleBackColor = true;
            this.cbUseSubGroupsUseExtendedShoppingRule.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbUseSubGroupsShopPagesLimit
            // 
            this.cbUseSubGroupsShopPagesLimit.AutoSize = true;
            this.cbUseSubGroupsShopPagesLimit.Location = new System.Drawing.Point(15, 90);
            this.cbUseSubGroupsShopPagesLimit.Name = "cbUseSubGroupsShopPagesLimit";
            this.cbUseSubGroupsShopPagesLimit.Size = new System.Drawing.Size(148, 18);
            this.cbUseSubGroupsShopPagesLimit.TabIndex = 4;
            this.cbUseSubGroupsShopPagesLimit.Text = "Limit of pages to view:";
            this.cbUseSubGroupsShopPagesLimit.UseVisualStyleBackColor = true;
            this.cbUseSubGroupsShopPagesLimit.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbUseSubGroupsIgnoreForShopping
            // 
            this.cbUseSubGroupsIgnoreForShopping.AutoSize = true;
            this.cbUseSubGroupsIgnoreForShopping.Location = new System.Drawing.Point(15, 17);
            this.cbUseSubGroupsIgnoreForShopping.Name = "cbUseSubGroupsIgnoreForShopping";
            this.cbUseSubGroupsIgnoreForShopping.Size = new System.Drawing.Size(15, 14);
            this.cbUseSubGroupsIgnoreForShopping.TabIndex = 0;
            this.cbUseSubGroupsIgnoreForShopping.UseVisualStyleBackColor = true;
            this.cbUseSubGroupsIgnoreForShopping.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbSubGroupsUseExtendedShoppingRule
            // 
            this.cbSubGroupsUseExtendedShoppingRule.AutoSize = true;
            this.cbSubGroupsUseExtendedShoppingRule.Checked = true;
            this.cbSubGroupsUseExtendedShoppingRule.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubGroupsUseExtendedShoppingRule.Location = new System.Drawing.Point(38, 65);
            this.cbSubGroupsUseExtendedShoppingRule.Name = "cbSubGroupsUseExtendedShoppingRule";
            this.cbSubGroupsUseExtendedShoppingRule.Size = new System.Drawing.Size(180, 18);
            this.cbSubGroupsUseExtendedShoppingRule.TabIndex = 3;
            this.cbSubGroupsUseExtendedShoppingRule.Text = "Use extended shopping rule";
            this.cbSubGroupsUseExtendedShoppingRule.UseVisualStyleBackColor = true;
            this.cbSubGroupsUseExtendedShoppingRule.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // cbSubGroupsIgnoreForShopping
            // 
            this.cbSubGroupsIgnoreForShopping.AutoSize = true;
            this.cbSubGroupsIgnoreForShopping.Location = new System.Drawing.Point(38, 15);
            this.cbSubGroupsIgnoreForShopping.Name = "cbSubGroupsIgnoreForShopping";
            this.cbSubGroupsIgnoreForShopping.Size = new System.Drawing.Size(133, 18);
            this.cbSubGroupsIgnoreForShopping.TabIndex = 1;
            this.cbSubGroupsIgnoreForShopping.Text = "Ignore for shopping";
            this.cbSubGroupsIgnoreForShopping.UseVisualStyleBackColor = true;
            this.cbSubGroupsIgnoreForShopping.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // tbSubGroupsShopPagesLimit
            // 
            this.tbSubGroupsShopPagesLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubGroupsShopPagesLimit.Location = new System.Drawing.Point(166, 88);
            this.tbSubGroupsShopPagesLimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.tbSubGroupsShopPagesLimit.Name = "tbSubGroupsShopPagesLimit";
            this.tbSubGroupsShopPagesLimit.Size = new System.Drawing.Size(60, 22);
            this.tbSubGroupsShopPagesLimit.TabIndex = 5;
            this.tbSubGroupsShopPagesLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pGameItems
            // 
            this.pGameItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pGameItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGameItems.Controls.Add(this.cbGameItemsUseInstantCostIfNoPublicCost);
            this.pGameItems.Controls.Add(this.tbGameItemsInstantPurchasePerz);
            this.pGameItems.Controls.Add(this.rbGameItemsInstantPurchasePerz);
            this.pGameItems.Controls.Add(this.rbGameItemsInstantPurchaseCost);
            this.pGameItems.Controls.Add(this.tbGameItemsInstantPurchaseCost);
            this.pGameItems.Location = new System.Drawing.Point(12, 151);
            this.pGameItems.Name = "pGameItems";
            this.pGameItems.Size = new System.Drawing.Size(241, 114);
            this.pGameItems.TabIndex = 3;
            // 
            // cbGameItemsUseInstantCostIfNoPublicCost
            // 
            this.cbGameItemsUseInstantCostIfNoPublicCost.Checked = true;
            this.cbGameItemsUseInstantCostIfNoPublicCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGameItemsUseInstantCostIfNoPublicCost.Location = new System.Drawing.Point(15, 71);
            this.cbGameItemsUseInstantCostIfNoPublicCost.Name = "cbGameItemsUseInstantCostIfNoPublicCost";
            this.cbGameItemsUseInstantCostIfNoPublicCost.Size = new System.Drawing.Size(211, 34);
            this.cbGameItemsUseInstantCostIfNoPublicCost.TabIndex = 4;
            this.cbGameItemsUseInstantCostIfNoPublicCost.Text = "Use current instant purchase cost if public cost is unknown";
            this.cbGameItemsUseInstantCostIfNoPublicCost.UseVisualStyleBackColor = true;
            // 
            // tbGameItemsInstantPurchasePerz
            // 
            this.tbGameItemsInstantPurchasePerz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameItemsInstantPurchasePerz.Location = new System.Drawing.Point(166, 43);
            this.tbGameItemsInstantPurchasePerz.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbGameItemsInstantPurchasePerz.Name = "tbGameItemsInstantPurchasePerz";
            this.tbGameItemsInstantPurchasePerz.Size = new System.Drawing.Size(60, 22);
            this.tbGameItemsInstantPurchasePerz.TabIndex = 3;
            this.tbGameItemsInstantPurchasePerz.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // rbGameItemsInstantPurchasePerz
            // 
            this.rbGameItemsInstantPurchasePerz.AutoSize = true;
            this.rbGameItemsInstantPurchasePerz.Location = new System.Drawing.Point(15, 44);
            this.rbGameItemsInstantPurchasePerz.Name = "rbGameItemsInstantPurchasePerz";
            this.rbGameItemsInstantPurchasePerz.Size = new System.Drawing.Size(150, 18);
            this.rbGameItemsInstantPurchasePerz.TabIndex = 2;
            this.rbGameItemsInstantPurchasePerz.Text = "or % of the factory cost:";
            this.rbGameItemsInstantPurchasePerz.UseVisualStyleBackColor = true;
            this.rbGameItemsInstantPurchasePerz.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // rbGameItemsInstantPurchaseCost
            // 
            this.rbGameItemsInstantPurchaseCost.AutoSize = true;
            this.rbGameItemsInstantPurchaseCost.Checked = true;
            this.rbGameItemsInstantPurchaseCost.Location = new System.Drawing.Point(15, 15);
            this.rbGameItemsInstantPurchaseCost.Name = "rbGameItemsInstantPurchaseCost";
            this.rbGameItemsInstantPurchaseCost.Size = new System.Drawing.Size(145, 18);
            this.rbGameItemsInstantPurchaseCost.TabIndex = 0;
            this.rbGameItemsInstantPurchaseCost.TabStop = true;
            this.rbGameItemsInstantPurchaseCost.Text = "Instant purchase cost:";
            this.rbGameItemsInstantPurchaseCost.UseVisualStyleBackColor = true;
            this.rbGameItemsInstantPurchaseCost.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // tbGameItemsInstantPurchaseCost
            // 
            this.tbGameItemsInstantPurchaseCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGameItemsInstantPurchaseCost.DecimalPlaces = 2;
            this.tbGameItemsInstantPurchaseCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tbGameItemsInstantPurchaseCost.Location = new System.Drawing.Point(166, 13);
            this.tbGameItemsInstantPurchaseCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbGameItemsInstantPurchaseCost.Name = "tbGameItemsInstantPurchaseCost";
            this.tbGameItemsInstantPurchaseCost.Size = new System.Drawing.Size(60, 22);
            this.tbGameItemsInstantPurchaseCost.TabIndex = 1;
            this.tbGameItemsInstantPurchaseCost.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbGameItems
            // 
            this.cbGameItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbGameItems.AutoSize = true;
            this.cbGameItems.Location = new System.Drawing.Point(19, 143);
            this.cbGameItems.Name = "cbGameItems";
            this.cbGameItems.Size = new System.Drawing.Size(141, 18);
            this.cbGameItems.TabIndex = 2;
            this.cbGameItems.Text = "Apply for game items";
            this.cbGameItems.UseVisualStyleBackColor = true;
            this.cbGameItems.CheckedChanged += new System.EventHandler(this.CbSubGroupsCheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.Location = new System.Drawing.Point(98, 276);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(179, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apply for subgroups";
            // 
            // frmSetGameItemsDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbGameItems);
            this.Controls.Add(this.pGameItems);
            this.Controls.Add(this.pSubGroups);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetGameItemsDefaults";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set defaults";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSetDefaultsForItemsGroupsKeyDown);
            this.pSubGroups.ResumeLayout(false);
            this.pSubGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubGroupsShopPagesLimit)).EndInit();
            this.pGameItems.ResumeLayout(false);
            this.pGameItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGameItemsInstantPurchasePerz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGameItemsInstantPurchaseCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pSubGroups;
        private System.Windows.Forms.NumericUpDown tbSubGroupsShopPagesLimit;
        private System.Windows.Forms.CheckBox cbSubGroupsIgnoreForShopping;
        private System.Windows.Forms.CheckBox cbSubGroupsUseExtendedShoppingRule;
        private System.Windows.Forms.Panel pGameItems;
        private System.Windows.Forms.CheckBox cbGameItems;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown tbGameItemsInstantPurchaseCost;
        private System.Windows.Forms.RadioButton rbGameItemsInstantPurchaseCost;
        private System.Windows.Forms.NumericUpDown tbGameItemsInstantPurchasePerz;
        private System.Windows.Forms.RadioButton rbGameItemsInstantPurchasePerz;
        private System.Windows.Forms.CheckBox cbGameItemsUseInstantCostIfNoPublicCost;
        private System.Windows.Forms.CheckBox cbUseSubGroupsUseExtendedShoppingRule;
        private System.Windows.Forms.CheckBox cbUseSubGroupsShopPagesLimit;
        private System.Windows.Forms.CheckBox cbUseSubGroupsIgnoreForShopping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbUseSubGroupsIgnoreForSelling;
        private System.Windows.Forms.CheckBox cbSubGroupsIgnoreForSelling;

    }
}