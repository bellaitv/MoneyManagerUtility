using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerUtility
{
    public class ItemCategory
    {
        public String Title { get; set; }
        public String Description { get; set; }

        public override bool Equals(object obj)
        {
            ItemCategory item = obj as ItemCategory;
            if (item == null)
                return false;
            if (!item.Title.Equals(this.Title))
                return false;
            if (!item.Description.Equals(this.Description))
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
