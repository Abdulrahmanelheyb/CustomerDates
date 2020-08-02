using CustomerDates.InsertUpdateViewClasses;
using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static CustomerDates.InsertUpdateViewClasses.InsertUpdateView;

namespace CustomerDates.DeviceControls
{
    public partial class CDevicesListAndControlsView
    {
        public void ComputersListAndControls()
        {
            ComputerData.LoadComputer();
            SearchPanel.Visibility = Visibility.Collapsed;
            DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            SetStatus(UCGetComputer());
            DevicesDataGrid.DataContext = new Computer();
            DevicesDataGrid.ItemsSource = Computer.ComputersProperty.DefaultView;

            SearchIO.Click += SearchComputerIO_Click;
            InsertButton.Click += InsertComputerButton_Click;
            UpdateButton.Click += UpdateComputerButton_Click;
            DeleteButton.Click += DeleteComputerButton_Click;
            ReportButton.Click += ReportComputerButton_Click;
            SearchButton.Click += SearchComputerButton_Click;
        }

        public static string UCGetComputer()
        {
            return "Computers";
        }

        private void SearchComputerIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility == Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
                DevicesDataGrid.ItemsSource = Computer.Computers.DefaultView;
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                DevicesDataGrid.Margin = new Thickness(33, 33, 0, 20);
            }
        }
        private void UpdateComputerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                InsertUpdateView update = new InsertUpdateView(DeviceType.Computer, OperationType.Update);
                update.SetComputer(Computer.GetComputer(DevicesDataGrid.SelectedIndex));
                update.Show();
            }
            else
            {
                SetStatus("Please Select Device To Update");
            }
        }
        private void DeleteComputerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ComputerData.DeleteComputer(Computer.GetComputer(DevicesDataGrid.SelectedIndex));
                SetStatus((ComputerData.LoadComputer() == true) ? "Delete is Completed" : "Delete is Failed");

            }

        }
        private void ReportComputerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ReportDevice report = new ReportDevice();
                report.LoadDevice(Computer.GetComputer(DevicesDataGrid.SelectedIndex));
                report.ShowDialog();
            }
        }
        private void InsertComputerButton_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateView insertcomputer = new InsertUpdateView(DeviceType.Computer, OperationType.Insert);
            insertcomputer.Show();
        }
        private void SearchComputerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SearchPropertyComboBox.SelectedIndex <= -1))
            {
                DevicesDataGrid.ItemsSource = ComputerData.SearchComputer(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
    }
}
