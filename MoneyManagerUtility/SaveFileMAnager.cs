using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerUtility
{
    public class SaveFileManager
    {
        public String name { get; set; }

        public void CreateNewTreeFile_Recursive(ref StringBuilder builder, TreeNode node)
        {
            foreach (TreeNode child in node.children)
            {
                foreach (String actual in Months.months)
                {
                    //todo hiba
                    if (child.Title.Equals(actual))
                    {
                        //save month
                        builder.AppendLine(String.Format(StringResources.SAVE_FORMAT_MONTH_START, child.Title));
                        CreateNewTreeFile_Recursive(ref builder, child);
                        builder.AppendLine(StringResources.SAVE_FORMAT_MONTH_END);
                        return;
                    }
                }
                NodeItem item = child as NodeItem;
                if (item != null)
                    //CATEGORY NULL
                    builder.AppendLine(String.Format(StringResources.SAVE_FORMAT_SHOPPING_ITEM_START, item.Title, item.Value, item.Description));
                else
                {
                    builder.AppendLine(String.Format(StringResources.SAVE_FORMAT_DAY_START, child.Title));
                    CreateNewTreeFile_Recursive(ref builder, child);
                    builder.AppendLine(StringResources.SAVE_FORMAT_DAY_END);
                    return;
                }
            }
        }
    }
}
