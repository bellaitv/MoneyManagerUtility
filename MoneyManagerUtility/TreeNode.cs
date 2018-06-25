using System;
using System.Linq;
using System.Collections.Generic;

namespace MoneyManagerUtility
{
    public class TreeNode
    {
        public TreeNode()
        {
        }

        public TreeNode(TreeNode parent) {
            this.parent = parent;
        }

        public String Title { get; set; }

        public TreeNode parent { get; set; }

        public List<TreeNode> children { get; set; }

        public ItemCategory Category { get; set; }

        public void AddChildren(List<TreeNode> children)
        {
            foreach (TreeNode child in children)
            {
                if (!this.children.Contains(child))
                    this.children.Add(child);
            }
            //SortChildren();
        }

        private void SortChildren()
        {
            //todo not tested!!
            List<TreeNode> copy = new List<TreeNode>(children);
            children.Clear();
            foreach (TreeNode node in copy)
            {
                int numberOfMonth = Months.WhichMonth(node.Title);
                children[numberOfMonth] = node;
            }
        }

        public override bool Equals(object obj)
        {
            TreeNode node = obj as TreeNode;
            if (node == null)
                return false;
            if (!node.Title.Equals(this.Title))
                return false;
            if (node.parent == null)
            {
                if (this.parent != null)
                    return false;
            }
            else if (this.parent == null)
                return false;
            else if (!node.parent.Equals(this.parent))
                return false;

            if (node.Category == null)
            {
                if (this.Category != null)
                    return false;
            }
            else if (this.Category == null)
                return false;
            else if (!node.Category.Equals(this.Category))
                return false;

            var firstNotSecond = node.children.Except(this.children).ToList();
            var secondNotFirst = this.children.Except(node.children).ToList();

            if (!firstNotSecond.Any() && !secondNotFirst.Any())
                return false;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            //todo
            return base.GetHashCode();
        }
    }
}
