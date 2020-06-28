using CustomerDates.Classes;
using CustomerDates.MainWindowControls;
using CustomerDates.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomerDates
{
    public partial class MainWindow
    {
        public void DockPanelLeftMW()
        {
            DockLeft.homebtn.Click += Homebtn_Click;
            DockLeft.Comp.Click += Comp_Click;
            
        }



        private void Comp_Click(object sender, RoutedEventArgs e)
        {
            
            
            DeviceRow dr2 = new DeviceRow();
            dr2.CustomerName.Content = "Abdulrahman";
            dr2.CustomerPhoneNumber.Content = "05684268423";
            dr2.DeviceCompany.Content = "Microsoft";
            dr2.Model.Content = "15-cc107nt";
            dr2.SerialNumber.Content = "035J83335H3";
            dr2.Price.Content = "350";
            dr2.InformationProvioslyEnteredCode.Content = "95NG8239V25";
            dr2.Date.Content = "2020/01/01";
            dr2.statusrec.Fill = Brushes.Lime;
          
        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("heee");
        }
    }
}
