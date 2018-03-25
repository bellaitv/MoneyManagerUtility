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
    /// Interaction logic for DialogSetMonths.xaml
    /// </summary>
    public partial class DialogSetShoppingItem : Window
    {

        private NodeItem item;
        private ItemReader reader;

        public DialogSetShoppingItem(ItemReader reader)
        {
            InitializeComponent();
            this.reader = reader;
            SetCategiies();
        }

        public DialogSetShoppingItem(NodeItem item, ItemReader reader)
        {
            InitializeComponent();
            this.item = item;
            this.reader = reader;
            SetCategiies();
        }

        private void SetCategiies()
        {
            List<Item> items = reader.File.GetItems();
            foreach (Item item in items)
            {
                ComboBoxItem comboItem = new ComboBoxItem() { Content = item.Category.Title };
                ComboboxCategories.Items.Add(comboItem);
            }
        }

        private void ApplySetMonths_Click(object sender, RoutedEventArgs e)
        {
            //item.title a hívó osztályba lesz kitöltve, az lesz a évhónapnap
            item.Value = String.Format("{0} {1}", ComboboxCategories.SelectedValue.ToString(), TextBoxAmount.Text.ToString());
            item.Description = TextBoxComment.Text.ToString();
        }

        private void CalcelSetMonths_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
