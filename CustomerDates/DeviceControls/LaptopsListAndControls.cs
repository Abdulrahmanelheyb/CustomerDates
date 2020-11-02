using CustomerDates.InsertUpdateViewClasses;
using CustomerDates.ViewModel.LaptopServices;
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
        public void LaptopsListAndControls()
        {
            LaptopData.LoadLaptop();
            SearchPanel.Visibility = Visibility.Collapsed;
            DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            SetStatus(UCGetLaptop());
            DevicesDataGrid.DataContext = new Laptop();
            DevicesDataGrid.ItemsSource = Laptop.LaptopsProperty.DefaultView;

            SearchIO.Click += SearchLaptopIO_Click;
            InsertButton.Click += InsertLaptopButton_Click;
            UpdateButton.Click += UpdateLaptopButton_Click;
            DeleteButton.Click += DeleteLaptopButton_Click;
            ReportButton.Click += ReportLaptopButton_Click;
            SearchButton.Click += SearchLaptopButton_Click;
        }

        public static string UCGetLaptop()
        {
            return "Laptops";
        }

        private void SearchLaptopIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility == Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
                DevicesDataGrid.ItemsSource = Laptop.Laptops.DefaultView;
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                DevicesDataGrid.Margin = new Thickness(33, 33, 0, 20);
            }
        }

        private void InsertLaptopButton_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateView InsertLaptop = new InsertUpdateView(DeviceType.Laptop, OperationType.Insert);
            InsertLaptop.ShowDialog();
        }

        private void UpdateLaptopButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex != -1)
            {

                InsertUpdateView UpdateLaptop = new InsertUpdateView(DeviceType.Laptop, OperationType.Update);
                UpdateLaptop.SetLaptop(Laptop.GetLaptop(DevicesDataGrid.SelectedIndex));
                UpdateLaptop.Show();
            }
            else
            {
                SetStatus("Please Select Device To Update");
            }

        }

        private void DeleteLaptopButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                LaptopData.DeleteLaptop(Laptop.GetLaptop(DevicesDataGrid.SelectedIndex));
                SetStatus((LaptopData.LoadLaptop() == true) ? "Delete is Completed" : "Delete is Failed");
            }
        }

        private void ReportLaptopButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ReportDevice report = new ReportDevice();
                report.LoadDevice(Laptop.GetLaptop(DevicesDataGrid.SelectedIndex));
                report.ShowDialog();
            }
        }

        private void SearchLaptopButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SearchPropertyComboBox.SelectedIndex <= -1))
            {
                DevicesDataGrid.ItemsSource = LaptopData.SearchLaptop(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
    }
}
