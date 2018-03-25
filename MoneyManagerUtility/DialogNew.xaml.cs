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
    /// Interaction logic for DialogNew.xaml
    /// </summary>
    public partial class DialogNew : Window
    {
        public const int MAX_ITEM_COUNT = 20;

        //Maybe unneeded
        private List<ComboBoxItem> years = new List<ComboBoxItem>();

        public DialogNew()
        {
            InitializeComponent();
            SetYearComboBox();
        }

        private void SetYearComboBox()
        {
            int maxYear = DateTime.Now.Year;
            for (int i = maxYear; i > maxYear - MAX_ITEM_COUNT; i--) {
                ComboBoxItem year = new ComboBoxItem() {Content = i };
                years.Add(year);
                ComboBoxYear.Items.Add(year);
            }
        }

        private void SetMonts_Click(object sender, RoutedEventArgs e)
        {
            DialogSetShoppingItem dialog = new DialogSetShoppingItem();
            dialog.ShowDialog();
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {

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
            DialogSetShoppingItem dialog = new DialogSetShoppingItem();
            dialog.ShowDialog();
        }
    }
}
