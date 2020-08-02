using CustomerDates.InsertUpdateViewClasses;
using CustomerDates.ViewModel.TabletServices;
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
        public void TabletsListAndControls()
        {
            TabletData.LoadTablet();
            SearchPanel.Visibility = Visibility.Collapsed;
            DevicesDataGrid.Margin = new Thickness(33, 0, 0, 20);
            SetStatus(UCGetTablet());
            DevicesDataGrid.DataContext = new ObjectLayer.Tablet();
            DevicesDataGrid.ItemsSource = ObjectLayer.Tablet.TabletsProperty.DefaultView;

            SearchIO.Click += SearchTabletIO_Click;
            InsertButton.Click += InsertTabletButton_Click;
            UpdateButton.Click += UpdateTabletButton_Click;
            DeleteButton.Click += DeleteTabletButton_Click;
            ReportButton.Click += ReportTabletButton_Click;
            SearchButton.Click += SearchTabletButton_Click;
        }

        public static string UCGetTablet()
        {
            return "Tablets";
        }

        private void SearchTabletIO_Click(object sender, RoutedEventArgs e)
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
        private void InsertTabletButton_Click(object sender, RoutedEventArgs e)
        {
            InsertUpdateView insert = new InsertUpdateView(DeviceType.Tablet, OperationType.Insert);
            insert.ShowDialog();
        }
        private void UpdateTabletButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                InsertUpdateView update = new InsertUpdateView(DeviceType.Tablet, OperationType.Update);
                update.SetTablet(ObjectLayer.Tablet.GetTablet(DevicesDataGrid.SelectedIndex));
                update.Show();
            }
            else
            {
                SetStatus("Please Select Device To Update");
            }
        }
        private void DeleteTabletButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                TabletData.DeleteTablet(ObjectLayer.Tablet.GetTablet(DevicesDataGrid.SelectedIndex));
                SetStatus((TabletData.LoadTablet() == true) ? "Delete is Completed" : "Delete is Failed");
            }
        }
        private void ReportTabletButton_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedIndex > -1)
            {
                ReportDevice report = new ReportDevice();
                report.LoadDevice(ObjectLayer.Tablet.GetTablet(DevicesDataGrid.SelectedIndex));
                report.ShowDialog();
            }
        }
        private void SearchTabletButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(SearchPropertyComboBox.SelectedIndex <= -1))
            {
                DevicesDataGrid.ItemsSource = TabletData.SearchTablet(((ComboBoxItem)SearchPropertyComboBox.SelectedItem).Tag.ToString(), SearchValueTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Select Property Type For Search");
            }
        }
    }
}
