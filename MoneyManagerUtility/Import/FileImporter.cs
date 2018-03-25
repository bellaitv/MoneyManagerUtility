using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerUtility.Import
{
    public abstract class FileImporter
    {
        protected String[] lines;

        //Head is always a year
        protected TreeNode head;
        protected TreeNode lastMonth, lastDay;
        protected ItemReader reader = new ItemReader();

        public abstract void Import();

        public abstract TreeNode GetHead();

        protected string DeleteSpacesFromEnd(string line)
        {
            String result = line;
            while (result[result.Length - 1] == ' ')
                result = result.Substring(0, result.Length - 1);
            return result.Trim();
        }
    }
}
