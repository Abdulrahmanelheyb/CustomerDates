using CustomerDates.InsertUpdateViewClasses;
using CustomerDates.ViewModel.OtherDeviceServices;
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
        public void OtherDevicesListAndControls()
        {
            OtherDeviceData.LoadOtherDevice();
            SearchPanel.Visibility = Visibility.Collapsed;
            DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            SetStatus(UCGetOtherDevice());
            DevicesDataGrid.DataContext = new OtherDevice();
            DevicesDataGrid.ItemsSource = OtherDevice.OtherDevicesProperty.DefaultView;

            SearchIO.Click += SearchOtherDeviceIO_Click;
            InsertButton.Click += InsertOtherDeviceButton_Click;
            UpdateButton.Click += UpdateOtherDeviceButton_Click;
            DeleteButton.Click += DeleteOtherDeviceButton_Click;
            ReportButton.Click += ReportOtherDeviceButton_Click;
            SearchButton.Click += SearchOtherDeviceButton_Click;
        }

        public static string UCGetOtherDevice()
        {
            return "Other Devices";
        }
        private void SearchOtherDeviceIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility == Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                DevicesDataGrid.Margin = new Thickness(33, 33, 0, 20);
            }
        }
        private void InsertOtherDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateView insert = new InsertUpdateView(DeviceType.OtherDevice, OperationType.Insert);
            insert.ShowDialog();
        }
        private void UpdateOtherDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                InsertUpdateView update = new InsertUpdateView(DeviceType.OtherDevice, OperationType.Insert);
                update.SetOtherDevice(OtherDevice.GetOtherDevice(DevicesDataGrid.SelectedIndex));
                update.ShowDialog();
            }

        }
        private void DeleteOtherDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                OtherDeviceData.DeleteOtherDevice(OtherDevice.GetOtherDevice(DevicesDataGrid.SelectedIndex));
                SetStatus((OtherDeviceData.LoadOtherDevice() == true) ? "Delete is Completed" : "Delete is Failed");
            }
        }
        private void ReportOtherDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ReportDevice report = new ReportDevice();
                report.LoadDevice(OtherDevice.GetOtherDevice(DevicesDataGrid.SelectedIndex));
                report.ShowDialog();
            }
        }
        private void SearchOtherDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SearchPropertyComboBox.SelectedIndex <= -1))
            {
                DevicesDataGrid.ItemsSource = OtherDeviceData.SearchOtherDevice(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
    }
}
