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

namespace MoneyManagerUtility
{
    /// <summary>
    /// Interaction logic for DialogModifyItem.xaml
    /// </summary>
    public partial class DialogModifyItem : Window
    {
        private NodeItem item;
        private ItemReader reader;

        public DialogModifyItem()
        {
            InitializeComponent();
            SetCategiies();
        }

        public DialogModifyItem(NodeItem item, ItemReader reader)
        {
            this.item = item;
            this.reader = reader;
            InitializeComponent();
            SetCategiies();
            InitializeValues();
        }

        private void SetCategiies()
        {
            List<Item> items = reader.File.GetItems();
            foreach (Item item in items)
            {
                String title = item.Category.Title;
                ComboBoxItem comboItem = new ComboBoxItem() { Content = title };
                ComboboxCategories.Items.Add(comboItem);
                if (this.item.Title.Equals(title))
                    ComboboxCategories.SelectedValue = title;
            }
        }


        private void InitializeValues()
        {

            String[] values = item.Value.Split(StringResources.asd);
            TextBoxAmount.Text = values[0];
            TextBoxComment.Text = values[1];
        }

        private void CalcelSetMonths_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplySetMonths_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
