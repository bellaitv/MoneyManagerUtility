using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            int mount = Months.WhichMonth(parentTitle);
            int to = 0;
            if (mount == 1)
                //TODO szökőév?
                to = 29;
            else if (mount == 0 || mount == 2 || mount == 4 || mount == 6 || mount == 7 || mount == 9 || mount == 11)
                to = 32;
            else
                to = 31;
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
