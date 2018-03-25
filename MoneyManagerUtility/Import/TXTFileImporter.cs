using System;
using System.Collections.Generic;
using System.IO;

namespace MoneyManagerUtility.Import
{
    public class TXTFileImporter : FileImporter
    {
        public String Title { get; private set; }

        public String error { get; private set; }

        public TXTFileImporter(String filePath, ItemReader reader) : base(reader)
        {
            lines = File.ReadAllLines(filePath);
            head = new TreeNode();
        }

        public override void Import()
        {
            int i = 0;
            foreach (String line in lines)
            {
                if (String.IsNullOrEmpty(line))
                    return;
                String trimmedLine = DeleteSpacesFromEnd(line);
                if (trimmedLine.EndsWith(StringResources.XML_END_SIGN))
                    trimmedLine = trimmedLine.Substring(0, trimmedLine.Length - 1);

                //todo: change to switch?
                if (IsYear(trimmedLine, i))
                    SetNodeToYear(trimmedLine);
                else if (IsMonth(trimmedLine))
                    SetNodeToMonth(trimmedLine);
                else if (IsDay(trimmedLine))
                    SetNodeToDay(trimmedLine);
                else if (!trimmedLine.Equals(StringResources.XML_SEPARATOR_DAY) && !(trimmedLine.Equals(StringResources.XML_SEPARATOR_DAILY_LIST_END)))
                    SetShoppingItem(trimmedLine);

                i++;
            }
        }

        private void SetShoppingItem(String line)
        {
            String[] strings = line.Split('=');
            String[] strings2 = strings[1].Split('-');
            bool isSum = line.StartsWith(StringResources.SUM);

            String description = isSum ? "" : strings2[1];
            NodeItem item = new NodeItem(reader) { Title = strings[0], Value = strings[1], Description = description };
            lastDay.children.Add(item);
        }

        private bool IsMonth(string line)
        {
            return Months.IsMonth(line);
        }

        private bool IsMonth(int line)
        {
            return Months.IsMonth(line);
        }

        private bool IsYear(string line, int lineNumber)
        {
            if (line.Length != 4)
                return false;
            int year = -1;
            Int32.TryParse(line, out year);
            if (year == -1)
            {
                error = String.Format("ERR:There is a problem in the line {0}", lineNumber);
                return false;
            }
            return true;
        }

        private void SetNodeToYear(string line)
        {
            head = new TreeNode() { Title = line, children = new List<TreeNode>() };
            Title = head.Title;
        }

        //sintax example: 200180307
        private bool IsDay(string line)
        {
            string year = line.Substring(0, 4);
            if (!IsYear(year, -1))
                return false;
            string month = line.Substring(4, 2);
            int iMonth = -1;
            Int32.TryParse(month, out iMonth);
            if (!IsMonth(iMonth))
                return false;
            string day = line.Substring(6, 2);
            int iDay = -1;
            Int32.TryParse(day, out iDay);

            if (!IsDay(iDay))
                return false;
            return true;
        }

        private bool IsDay(int day)
        {
            return (day >= 1 && day <= 21);
        }

        private void SetNodeToDay(String line)
        {
            TreeNode day = new TreeNode() { Title = line, children = new List<TreeNode>() };
            lastMonth.children.Add(day);
            lastDay = day;
        }

        private void SetNodeToMonth(String line)
        {
            TreeNode month = new TreeNode() { Title = line, children = new List<TreeNode>() };
            head.children.Add(month);
            lastMonth = month;
        }

        public override TreeNode GetHead()
        {
            return head;
        }
    }
}
