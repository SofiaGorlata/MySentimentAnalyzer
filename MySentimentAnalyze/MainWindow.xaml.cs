using MySentimentAnalyze.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MySentimentAnalyze
{
    public class IdConverter : IValueConverter
    {
        public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            ListViewItem item = (ListViewItem)value;
            ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            return (listView.Items.Count - index).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
