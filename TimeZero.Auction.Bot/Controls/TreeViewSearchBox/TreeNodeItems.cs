using System.Collections.Generic;
using System.Windows.Forms;

namespace TimeZero.Auction.Bot.Controls.TreeViewSearchBox
{
    class TreeNodeItems
    {
        public List<TreeNodeItem> Nodes;

        private void SaveNode(TreeNode node, List<TreeNodeItem> nodeItemsList)
        {
            TreeNode clonedNode = (TreeNode)node.Clone();
            TreeNodeItem nodeItem = new TreeNodeItem(clonedNode);
            nodeItemsList.Add(nodeItem);
            foreach (TreeNode childNode in clonedNode.Nodes)
            {
                SaveNode(childNode, nodeItem.Nodes);
            }
            clonedNode.Nodes.Clear();
        }

        public void Reload(TreeNodeCollection source)
        {
            Nodes = new List<TreeNodeItem>(source.Count);
            foreach (TreeNode node in source)
            {
                SaveNode(node, Nodes);
            }
        }

        public TreeNodeItems(TreeNodeCollection source)
        {
            Reload(source);
        }

        private void Assign(TreeNodeItem nodeItem, List<TreeNodeItem> nodeItemsList, 
                            bool isNodesHiddenDef)
        {
            TreeNodeItem clonedNodeItem = nodeItem.Clone(isNodesHiddenDef);
            nodeItemsList.Add(clonedNodeItem);
            foreach (TreeNodeItem childItem in nodeItem.Nodes)
            {
                Assign(childItem, clonedNodeItem.Nodes, isNodesHiddenDef);
            }            
        }

        public void Assign(TreeNodeItems source, bool isNodesHiddenDef)
        {
            Nodes = new List<TreeNodeItem>(source.Nodes.Count);
            foreach (TreeNodeItem item in source.Nodes)
            {
                Assign(item, Nodes, isNodesHiddenDef);
            }
        }

        public TreeNodeItems(TreeNodeItems source, bool isNodesHiddenDef)
        {
            Assign(source, isNodesHiddenDef);
        }

        private void AssignToTreeNodeCollectionTree(TreeNodeCollection dest, 
                                                    TreeNodeItem nodeItem)
        {
            if (!nodeItem.IsNodeHidden)
            {
                nodeItem.Node.Nodes.Clear();
                dest.Add(nodeItem.Node);
                foreach (TreeNodeItem childItem in nodeItem.Nodes)
                {
                    AssignToTreeNodeCollectionTree(nodeItem.Node.Nodes, childItem);
                }
            }
        }

        public void AssignToTreeNodeCollectionTree(TreeNodeCollection dest)
        {
            dest.Clear();
            foreach (TreeNodeItem item in Nodes)
            {
                AssignToTreeNodeCollectionTree(dest, item);
            }
        }

        private void AssignToTreeNodeCollectionList(TreeNodeCollection dest,
                                                    TreeNodeItem nodeItem)
        {
            foreach (TreeNodeItem childItem in nodeItem.Nodes)
            {
                AssignToTreeNodeCollectionList(dest, childItem);
            }
            if (!nodeItem.IsNodeHidden)
            {
                nodeItem.Node.Nodes.Clear();
                dest.Add(nodeItem.Node);
            }
        }

        public void AssignToTreeNodeCollectionList(TreeNodeCollection dest)
        {
            dest.Clear();
            foreach (TreeNodeItem item in Nodes)
            {
                AssignToTreeNodeCollectionList(dest, item);
            }
        }

        private void GetSelectedNodeFullPath(TreeNode node, TreeNodeItem nodeItem,
            List<string> pathList, ref bool found)
        {
            if (nodeItem.Node == node)
            {
                found = true;
                return;
            }

            foreach (TreeNodeItem childNodeItem in nodeItem.Nodes)
            {
                GetSelectedNodeFullPath(node, childNodeItem, pathList, ref found);
                if (found)
                {
                    pathList.Insert(0, childNodeItem.Node.Text);
                    break;
                }
            }
        }

        public string[] GetSelectedNodeFullPath(TreeNode node)
        {
            List<string> pathList = new List<string>();
            foreach (TreeNodeItem nodeItem in Nodes)
            {
                bool found = false;
                GetSelectedNodeFullPath(node, nodeItem, pathList, ref found);
                if (found)
                {
                    pathList.Insert(0, nodeItem.Node.Text);
                    break;
                }
            }
            return pathList.ToArray();
        }

        private TreeNode GetFirstFoundNode(TreeNodeItem nodeItem)
        {
            if (nodeItem.IsFoundNode)
            {
                return nodeItem.Node;
            }
            TreeNode foundNode = null;
            foreach (TreeNodeItem childNodeItem in nodeItem.Nodes)
            {
                if ((foundNode = GetFirstFoundNode(childNodeItem)) != null)
                {
                    break;
                }
            }
            return foundNode;
        }

        public TreeNode GetFirstFoundNode()
        {
            TreeNode foundNode = null;
            foreach (TreeNodeItem nodeItem in Nodes)
            {
                if ((foundNode = GetFirstFoundNode(nodeItem)) != null)
                {
                    break;
                }
            }
            return foundNode;
        }
    }
}