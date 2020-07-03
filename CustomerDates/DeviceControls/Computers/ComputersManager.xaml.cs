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
using BusinessLayer;
using CustomerDates.Classes;
using CustomerDates.UserControls;

namespace CustomerDates.DeviceControls
{
    /// <summary>
    /// Interaction logic for Computers.xaml
    /// </summary>
    public partial class ComputersManager : UserControl
    {
        public ComputersManager()
        {
            InitializeComponent();
            if (ComputerData.LoadComputer()== true)
            {
                ComputerUI.DeviceRows.Clear();
                ComputerUI.GetComputerRows();
                ComputerListBox.ItemsSource = ComputerUI.DeviceRows;
            }
            //ListColumnNames.CustomerName.Content = "Customer Name";
            //ListColumnNames.CustomerPhoneNumber.Content = "";
            //CustomerName.Content = 
            //CustomerPhoneNumber.Content =
            //DeviceCompany.Content = 
            //Model.Content = 
            //SerialNumber.Content = 
            //Price.Content = 
            //DeviceInformationCode.Content
            //Date.Content = 


        }

        public static string UCGetName()
        {
            return "Computers";
        }
        private void SearchIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility ==Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                ComputerListBox.Margin = new Thickness(33, 0, 0, 0);
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                ComputerListBox.Margin = new Thickness(33,33, 0, 0);
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertComputerMG insert = new InsertComputerMG();
            insert.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateComputerMG update = new UpdateComputerMG();
            update.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
