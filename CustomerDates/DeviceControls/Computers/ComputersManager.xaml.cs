using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CustomerDates;
using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;

namespace CustomerDates.DeviceControls.Computers
{
    /// <summary>
    /// Interaction logic for Computers.xaml
    /// </summary>
    public partial class ComputersManager : UserControl
    {
        public ComputersManager()
        {
            InitializeComponent();
            ComputerData.LoadComputer();
            SearchPanel.Visibility = Visibility.Collapsed;
            ListGrid.Margin = new Thickness(33, 0, 0, 0);
            SetStatus(UCGetName());
        }

        public static string UCGetName()
        {
            return "Computers";
        }
        private void SetStatus(string s)
        {
            OperationsStatus.Content = s;
        }
        
        private void SearchIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility ==Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                ListGrid.Margin = new Thickness(33, 0, 0, 0);
                DeviceListBox.DataContext = Computer.Computers;
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                ListGrid.Margin = new Thickness(33, 33, 0, 0);
                DeviceListBox.DataContext = ComputerData.SearchComputer();
            }
        }

        
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateComputerMG update = new UpdateComputerMG();
            if (DeviceListBox.SelectedIndex > -1)
            {
                update.SetComputerData(Computer.Computers[DeviceListBox.SelectedIndex]);
                update.Show();
            }
            else
            {
                SetStatus("Please Select Device To Update");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeviceListBox.SelectedIndex >-1)
            {
                if (ComputerData.DeleteComputer(Computer.Computers[DeviceListBox.SelectedIndex]) == true)
                {
                    ComputerData.LoadComputer();
                }
                
            }
            
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertComputerMG insert = new InsertComputerMG();
            insert.Show();
        }


        
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SearchPropertyComboBox.SelectedIndex <= -1))
            {
                DeviceListBox.ItemsSource = ComputerData.SearchComputer(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);

            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
        
    }
}
