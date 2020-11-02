using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.MobileServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CustomerDates.InsertUpdateViewClasses
{
    public partial class InsertUpdateView
    {
        public void InsertViewMobile()
        {
            Execute_btn.Click += ExcuteInsertButtonClickMobile;
        }

        public void LoadMobileFeatures()
        {
            //Hardwares
            hardwares = new Hardwares();
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Display", "Display"));

            //Softwares
            softwares = new Softwares();
            SoftwareStackPanel.Children.Add(softwares.CreateSoftware("Format", "Format"));

            //Extras
            extras = new Extras();
            Extras.Items.Add(extras.CreateExtra("Cover", "Cover"));
        }
        private void ExcuteInsertButtonClickMobile(object sender, RoutedEventArgs e)
        {

            if (mobile is null == false)
            {
                SetMassage("For Create New Mobile Please Press ESC To Empty Fields And Mobile's Mold");
                return;
            }
            mobile = new Mobile
            {
                CustomerName = NameTextBox.Text,
                CustomerPhoneNumber = PhoneNumberTextBox.Text,
                DeviceCompany = DeviceCompanyTextBox.Text,
                Model = ModelTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                Date = DateTime.Now,
                Hardwares = hardwares.WriteHardwaresXml(),
                Softwares = softwares.WriteSoftwaresXml(),
                Status = mobile.setStatus(),
                Extras = extras.WriteExtras()
            };

            try
            {
                mobile.Price = mobile.sumDevicePartsPrice();
                if (MobileData.InsertMobile(mobile) == true)
                {
                    SetMassage("Insert is completed");
                    SetMassageBackground(Brushes.LimeGreen);
                    PriceTextBox.Text = mobile.Price.ToString();
                }
                else
                {
                    SetMassage("Insert is failed");
                    SetMassageBackground(Brushes.Red);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR |\n" + ex.Message);
                SetMassage("Insert is failed");
                SetMassageBackground(Brushes.Red);
            }
            ClearFields();
            MobileData.LoadMobile();
        }

    }
}
