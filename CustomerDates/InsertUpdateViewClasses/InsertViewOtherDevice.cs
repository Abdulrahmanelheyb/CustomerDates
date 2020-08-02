using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.ComputerServices;
using CustomerDates.ViewModel.OtherDeviceServices;
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
        public void InsertViewOtherDevice()
        {
            Execute_btn.Click += ExcuteInsertButtonClickOtherDevice;
        }

        public void LoadOtherDeviceFeatures()
        {
            //Hardwares
            hardwares = new Hardwares();
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Charge Socket", "ChargeSocket"));


            //Softwares
            softwares = new Softwares();
            SoftwareStackPanel.Children.Add(softwares.CreateSoftware("Format", "Format"));

            //Extras
            extras = new Extras();
            Extras.Items.Add(extras.CreateExtra("Cable", "Cable"));
            Extras.Items.Add(extras.CreateExtra("Remote Control", "RemoteControl"));
            Extras.Items.Add(extras.CreateExtra("Device Box", "DeviceBox"));
        }
        private void ExcuteInsertButtonClickOtherDevice(object sender, RoutedEventArgs e)
        {

            if (otherdevice is null == false)
            {
                SetMassage("For Create New Other Device Please Press ESC To Empty Fields And Other Device's Mold");
                return;
            }
            otherdevice = new OtherDevice
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
                Status = otherdevice.SetStatus()
            };

            try
            {
                computer.Price = otherdevice.SumDevicePartsPrice();
                if (OtherDeviceData.InsertOtherDevice(otherdevice) == true)
                {
                    OperationStatus.Content = "Insert is completed";
                    PriceTextBox.Text = otherdevice.Price.ToString();
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
            OtherDeviceData.LoadOtherDevice();

        }

    }
}
