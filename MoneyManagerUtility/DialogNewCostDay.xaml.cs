using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace MoneyManagerUtility
{
    /// <summary>
    /// Interaction logic for NewCostDay.xaml
    /// </summary>
    public partial class DialogNewCostDay : Window
    {
        private ObservableCollection<int> days = new ObservableCollection<int>();
        private String parentTitle;
        private NodeItem item;

        public DialogNewCostDay()
        {
            InitializeComponent();
            InitializeList();
        }

        public DialogNewCostDay(String parentTitle, ItemReader reader)
        {
            InitializeComponent();
            this.parentTitle = parentTitle;
            item = new NodeItem(reader);
            InitializeList();
        }

        private void InitializeList()
        {
            for (int i = 1; i < 32; i++)
                days.Add(i);
            ComboBoxDays.ItemsSource = days;
        }

        public NodeItem GetItem()
        {
            return item;
        }

        private void ApplySetMonths_Click(object sender, RoutedEventArgs e)
        {
            int day = (int)ComboBoxDays.SelectedValue;
            item.Value = day.ToString();
            item.Title = day.ToString();
            DialogResult = true;
        }

        private void CalcelSetMonths_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
