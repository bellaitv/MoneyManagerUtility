﻿using System;
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
        public DialogSetShoppingItem()
        {
            InitializeComponent();
            SetCategiies();
        }

        private void SetCategiies()
        {
            ItemReader reader = new ItemReader();
            List<Item> items = reader.File.GetItems();
            foreach (Item item in items) {
                ComboBoxItem comboItem = new ComboBoxItem() { Content = item.Category.Title };
                ComboboxCategories.Items.Add(comboItem);
            }
        }

        private void ApplySetMonths_Click(object sender, RoutedEventArgs e)
        {

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
