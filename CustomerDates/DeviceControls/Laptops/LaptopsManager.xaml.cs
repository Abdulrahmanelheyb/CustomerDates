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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CustomerDates.ViewModel;
using CustomerDates.ViewModel.LaptopServices;

namespace CustomerDates.DeviceControls.Laptops
{
    /// <summary>
    /// Interaction logic for Computers.xaml
    /// </summary>
    public partial class LaptopsManager : UserControl
    {
        public LaptopsManager()
        {
            InitializeComponent();
            LaptopData.LoadLaptop();
        }

        public static string UCGetName()
        {
            return "Laptops";
        }
        private void SearchIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility ==Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                LaptopDataGrid.Margin = new Thickness(33, 0, 0, 20);
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                LaptopDataGrid.Margin = new Thickness(33,33, 0, 20);
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
