using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyManagerUtility
{
    /// <summary>
    /// Interaction logic for DialogNew.xaml
    /// </summary>
    public partial class DialogNew : Window
    {
        public const int MAX_ITEM_COUNT = 20;

        //Maybe unneeded
        private ItemReader reader;
        private List<TreeNode> months;
        private TreeNode head;
        private MainWindow main;

        public DialogNew(ItemReader reader, MainWindow main)
        {
            InitializeComponent();
            this.reader = reader;
            this.main = main;
            months = new List<TreeNode>();
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            head = new TreeNode() { children = months, Title = Calendar_New_Item.SelectedDate.Value.Year.ToString() };
            //todo save the current tree, maybe ask the user
            main.SetHead(head);
            main.ClearTheTree();
            main.SetTree(head);
            Close();
        }

        private void CancelNew_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelectionChangedYearNew(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox == null)
                return;
            string text = (e.AddedItems[0] as ComboBoxItem).Content as string;
            combobox.Text = text;
        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeNode month = GetMonth(Calendar_New_Item.SelectedDate.Value.Month);
            if (IsnewMonth(month))
                months.Add(month);

            NodeItem item = new NodeItem(reader);
            DialogSetShoppingItem dialog = new DialogSetShoppingItem(item, reader);
            dialog.ShowDialog();
            //month.children.Add(item);
            String stringDay = Calendar_New_Item.SelectedDate.Value.Day.ToString();
            AddItemToMonth(month, stringDay, item);
        }

        private void AddItemToMonth(TreeNode month, String stringDay, TreeNode item)
        {
            foreach (TreeNode day in month.children)
            {
                if (day != null && day.Title.Equals(stringDay))
                {
                    day.children.Add(item);
                    return;
                }
            }
            TreeNode actualDay = new TreeNode() { children = new List<TreeNode>(), Title = stringDay, parent = month };
            actualDay.children.Add(item);
            month.children.Add(actualDay);
        }

        private bool IsnewMonth(TreeNode month)
        {
            foreach (TreeNode actual in months)
                if (actual.Title.ToString().Equals(month.Title.ToString()))
                    return false;
            return true;
        }

        private TreeNode GetMonth(int month)
        {
            //month -1 because january is 0
            String actualMonthString = Months.GetMonth(month - 1);
            TreeNode result = new TreeNode() { Title = actualMonthString, children = new List<TreeNode>() };
            foreach (TreeNode actualMonth in months)
                if (actualMonth != null && actualMonth.Title.Equals(actualMonthString))
                    result = actualMonth;
            return result;
        }
    }
}