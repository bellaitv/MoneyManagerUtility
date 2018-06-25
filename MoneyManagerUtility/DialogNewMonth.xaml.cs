using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MoneyManagerUtility
{
    /// <summary>
    /// Interaction logic for DialogNewMonth.xaml
    /// </summary>
    public partial class DialogNewMonth : Window
    {
        private ObservableCollection<String> values = new ObservableCollection<String>();

        private TreeNode item;

        public DialogNewMonth()
        {
            InitializeComponent();
        }

        public DialogNewMonth(List<TreeNode> existingValues, TreeNode parent)
        {
            InitializeComponent();
            item = new TreeNode(parent);
            InitializeCombobox(existingValues);
        }

        private void InitializeCombobox(List<TreeNode> existingValues)
        {
            List<String> allMonths = new List<string>(Months.months);
            List<String> usedMonths = new List<string>();

            foreach (TreeNode actualNode in existingValues)
                usedMonths.Add(actualNode.Title);

            foreach (String actual in allMonths)
                if (!usedMonths.Contains(actual) && !values.Contains(actual))
                    values.Add(actual);    
            ComboboxMonths.ItemsSource = values;
        }

        private void SelectionChanged_Months(object sender, SelectionChangedEventArgs e)
        {
            String selectedValue = ComboboxMonths.SelectedValue as String;
            item.Title = selectedValue;
            //item.Value = selectedValue;
            DialogResult = true;
        }

        public TreeNode GetItem()
        {
            return item;
        }
    }
}
