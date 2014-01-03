using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Controls.TreeViewSearchBox
{
    internal class TreeNodeItem
    {
        public TreeNode Node;
        public List<TreeNodeItem> Nodes;
        public bool IsNodeHidden;
        public bool IsFoundNode;

        public TreeNodeItem()
        {
            Nodes = new List<TreeNodeItem>();
        }

        public TreeNodeItem(TreeNode node)
        {
            Node = node;
            Nodes = new List<TreeNodeItem>();
        }

        public TreeNodeItem Clone(bool isNodeHiddenDef)
        {
            return new TreeNodeItem(Node) { IsNodeHidden = isNodeHiddenDef, 
                                            Node = (TreeNode) Node.Clone() };
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Node.Text, Nodes.Count);
        }
    }
}