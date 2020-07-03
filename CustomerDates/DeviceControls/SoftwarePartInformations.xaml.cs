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
    /// Interaction logic for SoftwarePartInformations.xaml
    /// </summary>
    public partial class SoftwarePartInformations : UserControl
    {
        public SoftwarePartInformations()
        {
            InitializeComponent();
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
