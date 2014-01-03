using System;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Forms
{
    public partial class frmSetGameItemsDefaults : Form
    {

#region Properties

        //Subgroups
        public bool UseSubGroupsIgnoreForShopping
        {
            get { return cbUseSubGroupsIgnoreForShopping.Checked; }
        }
        public bool SubGroupsIgnoreForShopping
        {
            get { return cbSubGroupsIgnoreForShopping.Checked; } 
        }

        public bool UseSubGroupsUseExtendedShoppingRule
        {
            get { return cbUseSubGroupsUseExtendedShoppingRule.Checked; }
        }
        public bool SubGroupsUseExtendedShoppingRule
        {
            get { return cbSubGroupsUseExtendedShoppingRule.Checked; } 
        }

        public bool UseSubGroupsShopPagesLimit
        {
            get { return cbUseSubGroupsShopPagesLimit.Checked; }
        }
        public byte SubGroupsShopPagesLimit
        {
            get { return (byte)tbSubGroupsShopPagesLimit.Value; } 
        }

        //Game items
        public bool ApplyForGameItems
        {
            get { return cbGameItems.Checked; }
        }
        public bool InstantPurchaseByPerz
        {
            get { return rbGameItemsInstantPurchasePerz.Checked; }
        }
        public float InstantPurchaseCost
        {
            get { return float.Parse(tbGameItemsInstantPurchaseCost.Text); }
        }
        public int InstantPurchasePerz
        {
            get { return int.Parse(tbGameItemsInstantPurchasePerz.Text); }
        }
        public bool UseCurrentInstantPurchaseCostIfNoPublicCost
        {
            get { return cbGameItemsUseInstantCostIfNoPublicCost.Checked; }
        }

#endregion

#region Class methods

        public frmSetGameItemsDefaults()
        {
            InitializeComponent();
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            cbSubGroupsIgnoreForShopping.Enabled = UseSubGroupsIgnoreForShopping;
            cbSubGroupsUseExtendedShoppingRule.Enabled = UseSubGroupsUseExtendedShoppingRule;
            tbSubGroupsShopPagesLimit.Enabled = UseSubGroupsShopPagesLimit;

            pGameItems.Enabled = ApplyForGameItems;
            tbGameItemsInstantPurchaseCost.Enabled = !InstantPurchaseByPerz;
            tbGameItemsInstantPurchasePerz.Enabled = InstantPurchaseByPerz;
            cbGameItemsUseInstantCostIfNoPublicCost.Enabled = InstantPurchaseByPerz;

            btnApply.Enabled = UseSubGroupsIgnoreForShopping ||
                               UseSubGroupsUseExtendedShoppingRule ||
                               UseSubGroupsShopPagesLimit ||
                               ApplyForGameItems;
        }

        private void CbSubGroupsCheckedChanged(object sender, EventArgs e)
        {
            UpdateInterface();
        }

        public bool Execute()
        {
            return ShowDialog() == DialogResult.OK;
        }

        private void FrmSetDefaultsForItemsGroupsKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

#endregion

    }
}
