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
    public partial class DialogModifyCostItem : Window
    {
        private NodeItem item;
        private ItemReader reader;

        public DialogModifyCostItem()
        {
            InitializeComponent();
            SetCategiies();
        }

        public DialogModifyCostItem(NodeItem item, ItemReader reader)
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
            
            foreach (ComboBoxItem actual in ComboboxCategories.Items) {
                if (actual.Content.Equals(item.Title))
                {
                    ComboboxCategories.SelectedValue = actual;
                    return;
                }
            }
        }

        private void CalcelSetMonths_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ApplySetMonths_Click(object sender, RoutedEventArgs e)
        {
            if (!FormIsValid())
                return;
            ComboBoxItem category = (ComboBoxItem)ComboboxCategories.SelectedValue;
            if (category == null)
                //todo show error to user?
                return;
            item.Title = category.Content.ToString();

            //todo MODIFY - in the imports as well
            String value = String.Format("{0}{1}{2}", TextBoxAmount.Text.ToString(), StringResources.asd, TextBoxComment.Text.ToString());
            item.Value = value;
            item.Description = value;
            DialogResult = true;
        }

        private bool FormIsValid()
        {
            ComboBoxItem category = (ComboBoxItem)ComboboxCategories.SelectedValue;
            if (category == null)
            {
                MessageBox.Show(String.Format(StringResources.ERROR_MSG_EMPTY_CONTENT, "Category"), StringResources.ERROR_MSG_TITLE);
                return false;
            }
            if (String.IsNullOrEmpty(TextBoxAmount.Text.ToString()))
            {
                MessageBox.Show(String.Format(StringResources.ERROR_MSG_EMPTY_CONTENT, "Amount"), StringResources.ERROR_MSG_TITLE);
                return false;
            }
            return true;
        }
    }
}
