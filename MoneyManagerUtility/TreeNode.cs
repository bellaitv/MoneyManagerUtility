using System;
using System.Collections.Generic;

namespace MoneyManagerUtility
{
    public class TreeNode
    {
        public String Title { get; set; }

        public TreeNode parent { get; set; }

        public List<TreeNode> children { get; set; }

        public ItemCategory Category { get; set; }
    }
}
