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

namespace CustomerDates.DeviceControls
{
    /// <summary>
    /// Interaction logic for DevicesListAndControlsView.xaml
    /// </summary>
    public partial class CDevicesListAndControlsView : UserControl
    {
        public enum CDeviceType { Computer ,Laptop ,Mobile ,Tablet ,OtherDevice}
        public CDevicesListAndControlsView(CDeviceType deviceType)
        {
            InitializeComponent();
            if (deviceType == CDeviceType.Computer)
            {
                ComputersListAndControls();
            }
            else if (deviceType == CDeviceType.Laptop)
            {
                LaptopsListAndControls();
            }
            else if (deviceType == CDeviceType.Mobile)
            {
                MobilesListAndControls();
            }
            else if (deviceType == CDeviceType.Tablet)
            {
                TabletsListAndControls();
            }
            else
            {
                OtherDevicesListAndControls();
            }
        }

        private void SetStatus(string s)
        {
            OperationsStatus.Content = s;
        }
    }
}
