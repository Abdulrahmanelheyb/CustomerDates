using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerDates.DeviceControls
{
    /// <summary>
    /// Interaction logic for SoftwarePartInformations.xaml
    /// </summary>
    public partial class SoftwarePartInformations : UserControl
    {
        public SoftwarePartInformations()
        {
            InitializeComponent();
        }

        #region SetDevice
        public bool SetDevice(Computer computer)
        {
            if (computer is null) { return false; }
            return (string.IsNullOrEmpty(computer.DeviceInformationCode) == false) ? true : false;
        }
        public bool SetDevice(Laptop laptop)
        {
            if (laptop is null) { return false; }
            return (string.IsNullOrEmpty(laptop.DeviceInformationCode) == false) ? true : false;
        }
        public bool SetDevice(Mobile mobile)
        {
            if (mobile is null) { return false; }
            return (string.IsNullOrEmpty(mobile.DeviceInformationCode) == false) ? true : false;
        }
        public bool SetDevice(Tablet tablet)
        {
            if (tablet is null) { return false; }
            return (string.IsNullOrEmpty(tablet.DeviceInformationCode) == false) ? true : false;
        }
        public bool SetDevice(OtherDevice otherdevice)
        {
            if (otherdevice is null) { return false; }
            return (string.IsNullOrEmpty(otherdevice.DeviceInformationCode) == false) ? true : false;
        }
        #endregion

        public void ResetControls()
        {
            parttypecbx.SelectedIndex = -1;
            descriptiontbx.Text = "";
            pricetbx.Text = "";
            Completed.IsChecked = false;
            Repairing.IsChecked = false;
            Failed.IsChecked = false;
            datagrid.ItemsSource = null;
        }

        private void Repairing_Checked(object sender, RoutedEventArgs e)
        {
            Completed.IsChecked = false;
            Failed.IsChecked = false;
        }

        private void Completed_Checked(object sender, RoutedEventArgs e)
        {
            Repairing.IsChecked = false;
            Failed.IsChecked = false;
        }

        private void Failed_Checked(object sender, RoutedEventArgs e)
        {
            Repairing.IsChecked = false;
            Completed.IsChecked = false;
        }
    }
}
