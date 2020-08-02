using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace CustomerDates
{
    

    public static class ReportVars
    {
       static public string Selectedvalue { get; set; }
       

        
    }
    public partial class ReportDevice : Window
    {
        public ReportDevice()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = SystemParameters.WorkArea.Width/2;
            
            
        }

        #region  Window Methods 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }
        private void bormenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void Minimizebtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else { this.WindowState = WindowState.Minimized; }
        }




        private void Maximizebtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else { this.WindowState = WindowState.Normal; }
        }


        private void MMbtnexit_Click(object sender, RoutedEventArgs e)
        {
            //add save warning save and cancel .
            this.Close();
        }







        #endregion

        private void grd_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            dg.SelectedIndex = -1;
            dg.SelectedItem = -1;

        }

        public void ReadExtras(string Extras)
        {
            if (string.IsNullOrEmpty(Extras) == true && string.IsNullOrWhiteSpace(Extras) == true)
            {
                return;
            }
            XmlReader reader = XmlReader.Create(new StringReader(Extras));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Extras")
                {
                    ExtrasLbl.Content += reader.Name + ",";
                }
            }
        }
        public void ReadHardwares(string hardwares)
        {
            if (string.IsNullOrEmpty(hardwares) == true && string.IsNullOrWhiteSpace(hardwares) == true)
            {
                return;
            }
            int numberofhardware = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PartName"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Price"));
            dt.Columns.Add(new DataColumn("Status"));
            XmlReader reader = XmlReader.Create(new StringReader(hardwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Hardwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                        DataRow r = dt.NewRow();
                        r[0] = reader.Name.ToString();
                        r[1] = reader.GetAttribute("Description");
                        r[2] = reader.GetAttribute("Price");
                        r[3] = reader.GetAttribute("Status");
                        numberofhardware++;
                        dt.Rows.Add(r);
                    }
                }
            }
            NumberOfHardwareLbl.Content = numberofhardware;
            HardwaresDataGrid.ItemsSource = dt.DefaultView;
        }
        public void ReadSoftwares(string softwares)
        {
            if (string.IsNullOrEmpty(softwares) == true && string.IsNullOrWhiteSpace(softwares) == true)
            {
                return;
            }
            int numberofsoftware = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PartName"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Price"));
            dt.Columns.Add(new DataColumn("Status"));
            XmlReader reader = XmlReader.Create(new StringReader(softwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Softwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                        DataRow r = dt.NewRow();
                        r[0] = reader.Name.ToString();
                        r[1] = reader.GetAttribute("Description");
                        r[2] = reader.GetAttribute("Price");
                        r[3] = reader.GetAttribute("Status");
                        numberofsoftware++;
                        dt.Rows.Add(r);
                    }
                }
            }
            NumberOfSoftwareLbl.Content = numberofsoftware;
            softwaresDataGrid.ItemsSource = dt.DefaultView;
        }

        public void LoadDevice(Computer computer)
        {
            ExtrasRow.Height = new GridLength(0);
            NameLbl.Content = computer.CustomerName;
            PhoneNumberLbl.Content = computer.CustomerPhoneNumber;
            DeviceCompanyLbl.Content = computer.DeviceCompany;
            ModelLbl.Content = computer.Model;
            SerialNumberLbl.Content = computer.SerialNumber;
            PriceLbl.Content = computer.Price;
            DateLbl.Content = computer.Date;
            ReadHardwares(computer.Hardwares);
            ReadSoftwares(computer.Softwares);

        }
        public void LoadDevice(Laptop laptop)
        {
            NameLbl.Content = laptop.CustomerName;
            PhoneNumberLbl.Content = laptop.CustomerPhoneNumber;
            DeviceCompanyLbl.Content = laptop.DeviceCompany;
            ModelLbl.Content = laptop.Model;
            SerialNumberLbl.Content = laptop.SerialNumber;
            PriceLbl.Content = laptop.Price;
            DateLbl.Content = laptop.Date;
            ReadHardwares(laptop.Hardwares);
            ReadSoftwares(laptop.Softwares);
            ReadExtras(laptop.Extras);
        }
        public void LoadDevice(Mobile mobile)
        {
            NameLbl.Content = mobile.CustomerName;
            PhoneNumberLbl.Content = mobile.CustomerPhoneNumber;
            DeviceCompanyLbl.Content = mobile.DeviceCompany;
            ModelLbl.Content = mobile.Model;
            SerialNumberLbl.Content = mobile.SerialNumber;
            PriceLbl.Content = mobile.Price;
            DateLbl.Content = mobile.Date;
            ReadHardwares(mobile.Hardwares);
            ReadSoftwares(mobile.Softwares);
            ReadExtras(mobile.Extras);
        }
        public void LoadDevice(ObjectLayer.Tablet tablet)
        {
            NameLbl.Content = tablet.CustomerName;
            PhoneNumberLbl.Content = tablet.CustomerPhoneNumber;
            DeviceCompanyLbl.Content = tablet.DeviceCompany;
            ModelLbl.Content = tablet.Model;
            SerialNumberLbl.Content = tablet.SerialNumber;
            PriceLbl.Content = tablet.Price;
            DateLbl.Content = tablet.Date;
            ReadHardwares(tablet.Hardwares);
            ReadSoftwares(tablet.Softwares);
            ReadExtras(tablet.Extras);
        }
        public void LoadDevice(OtherDevice otherDevice)
        {
            NameLbl.Content = otherDevice.CustomerName;
            PhoneNumberLbl.Content = otherDevice.CustomerPhoneNumber;
            DeviceCompanyLbl.Content = otherDevice.DeviceCompany;
            ModelLbl.Content = otherDevice.Model;
            SerialNumberLbl.Content = otherDevice.SerialNumber;
            PriceLbl.Content = otherDevice.Price;
            DateLbl.Content = otherDevice.Date;
            ReadHardwares(otherDevice.Hardwares);
            ReadSoftwares(otherDevice.Softwares);
            ReadExtras(otherDevice.Extras);
        }
    }
}
