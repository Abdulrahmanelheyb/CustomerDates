using CustomerDates.InsertUpdateViewClasses;
using CustomerDates.ViewModel.MobileServices;
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
        public void MobilesListAndControls()
        {
            MobileData.LoadMobile();
            SearchPanel.Visibility = Visibility.Collapsed;
            DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            SetStatus(UCGetMobile());
            DevicesDataGrid.DataContext = new Mobile();
            DevicesDataGrid.ItemsSource = Mobile.MobilesProperty.DefaultView;

            SearchIO.Click += SearchMobileIO_Click;
            InsertButton.Click += InsertMobileButton_Click;
            UpdateButton.Click += UpdateMobileButton_Click;
            DeleteButton.Click += DeleteMobileButton_Click;
            ReportButton.Click += ReportMobileButton_Click;
            SearchButton.Click += SearchMobileButton_Click;
        }

        public static string UCGetMobile()
        {
            return "Mobiles";
        }

        private void SearchMobileIO_Click(object sender, RoutedEventArgs e)
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
        private void InsertMobileButton_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateView insert = new InsertUpdateView(DeviceType.Mobile, InsertUpdateView.OperationType.Insert);
            insert.Show();
        }
        private void UpdateMobileButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                InsertUpdateView update = new InsertUpdateView(DeviceType.Mobile, OperationType.Update);
                update.SetMobile(Mobile.GetMobile(DevicesDataGrid.SelectedIndex));
                update.Show();
            }

        }
        private void DeleteMobileButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                MobileData.DeleteMobile(Mobile.GetMobile(DevicesDataGrid.SelectedIndex));
                MobileData.LoadMobile();
            }
        }
        private void ReportMobileButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ReportDevice report = new ReportDevice();
                report.LoadDevice(Mobile.GetMobile(DevicesDataGrid.SelectedIndex));
                report.ShowDialog();
            }
        }
        private void SearchMobileButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPropertyComboBox.SelectedIndex > -1)
            {
                DevicesDataGrid.ItemsSource = MobileData.SearchMobile(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
    }
}
