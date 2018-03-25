using System;

namespace MoneyManagerUtility
{
    public class NodeItem : TreeNode
    {
        private String title;
        public ItemReader reader { get; private set; }
        public String Description { get; set; }

        public String Value { get; set; }

        public NodeItem(ItemReader reader)
        {
            this.reader = reader;
        }

        public new String Title
        {
            get { return title; }
            set
            {
                if (!reader.IsCategory(value))
                    return;
                title = value;
                base.Title = value;
            }
        }
    }
}
