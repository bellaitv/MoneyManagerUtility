using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerUtility.Import
{
    public interface IImporter
    {
        void Import();

        TreeNode GetHead();
    }
}
