using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.ComputerServices;
using CustomerDates.ViewModel.TabletServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomerDates.InsertUpdateViewClasses
{
    public partial class InsertUpdateView
    {
        public void InsertViewTablet()
        {
            Execute_btn.Click += ExcuteInsertButtonClickTablet;
        }

        public void LoadTabletFeatures()
        {
            //Hardwares
            hardwares = new Hardwares();
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Charge Socket", "ChargeSocket"));


            //Softwares
            softwares = new Softwares();
            SoftwareStackPanel.Children.Add(softwares.CreateSoftware("Format", "Format"));

            //Extras
            extras = new Extras();
            Extras.Items.Add(extras.CreateExtra("Cover", "Cover"));
        }
        private void ExcuteInsertButtonClickTablet(object sender, RoutedEventArgs e)
        {

            if (tablet is null == false)
            {
                SetMassage("For Create New Tablet Please Press ESC To Empty Fields And Tablet's Mold");
                return;
            }
            tablet = new Tablet
            {
                CustomerName = NameTextBox.Text,
                CustomerPhoneNumber = PhoneNumberTextBox.Text,
                DeviceCompany = DeviceCompanyTextBox.Text,
                Model = ModelTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                Date = DateTime.Now,
                Hardwares = hardwares.WriteHardwaresXml(),
                Softwares = softwares.WriteSoftwaresXml(),
                Extras = extras.WriteExtras(),
                Status = tablet.SetStatus()
            };

            try
            {
                tablet.Price = tablet.SumDevicePartsPrice();
                if (TabletData.InsertTablet(tablet) == true)
                {
                    OperationStatus.Content = "Insert is completed";
                    PriceTextBox.Text = tablet.Price.ToString();
                }
                else
                {
                    OperationStatus.Content = "Insert is failed";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR |\n" + ex.Message);
                OperationStatus.Content = "Insert is failed";
            }
            TabletData.LoadTablet();

        }

    }
}
