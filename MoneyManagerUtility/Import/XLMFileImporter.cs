using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace MoneyManagerUtility.Import
{
    public class XLMFileImporter : FileImporter
    {

        private String filePath;

        public XLMFileImporter(String filePath, ItemReader reader) : base(reader)
        {
            this.reader = reader;
            this.filePath = filePath;
            head = new TreeNode(null) { children = new List<TreeNode>() };
        }

        public String Title { get; private set; }

        private ItemReader reader = new ItemReader();

        public String error { get; private set; }

        public override TreeNode GetHead()
        {
            return head;
        }

        public override void Import()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlElement year = doc.DocumentElement;
            head.Title = year.Attributes[0].Value;
            XmlNodeList months = doc.DocumentElement.ChildNodes;
            List<TreeNode> monhtsList = new List<TreeNode>();
            foreach (XmlNode month in months)
            {
                TreeNode monthNode = new TreeNode(head) { Title = month.Attributes[0].Value, children = new List<TreeNode>() };
                head.children.Add(monthNode);
                lastMonth = monthNode;
                foreach (XmlNode day in month.ChildNodes)
                {
                    TreeNode dayNode = new TreeNode(monthNode) { Title = day.Attributes[0].Value, children = new List<TreeNode>() };
                    monthNode.children.Add(dayNode);
                    foreach (XmlNode shoppingItem in day.ChildNodes)
                    {
                        NodeItem shoppingItemNode = new NodeItem(dayNode, reader) { Title = shoppingItem.Attributes[0].Value, Value = shoppingItem.Attributes[1].Value, Description = shoppingItem.Attributes[2].Value, children = new List<TreeNode>() };
                        dayNode.children.Add(shoppingItemNode);
                    }
                }
            }
        }
    }
}
