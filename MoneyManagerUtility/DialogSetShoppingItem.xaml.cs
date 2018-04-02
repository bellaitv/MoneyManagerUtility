﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            ComboBoxItem category = (ComboBoxItem)ComboboxCategories.SelectedValue;
            item.Title = category.Content.ToString();

            //todo MODIFY - in the imports as well
            String value = String.Format("{0} {1}", TextBoxAmount.Text.ToString(), TextBoxComment.Text.ToString());
            item.Value = value;
            item.Description = value;
            Close();
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