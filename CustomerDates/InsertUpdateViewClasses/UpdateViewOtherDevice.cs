using CustomerDates.ViewModel.LaptopServices;
using CustomerDates.ViewModel.OtherDeviceServices;
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
        public void UpdateViewOtherDevice()
        {
            Execute_btn.Click += ExcuteUpdateButtonClickOtherDevice;
        }

        public void SetOtherDevice(OtherDevice otherdevice)
        {
            this.otherdevice = otherdevice;
            NameTextBox.Text = otherdevice.CustomerName;
            PhoneNumberTextBox.Text = otherdevice.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = otherdevice.DeviceCompany;
            ModelTextBox.Text = otherdevice.Model;
            SerialNumberTextBox.Text = otherdevice.SerialNumber;
            hardwares.ReadHardwaresXml(otherdevice.Hardwares);
            softwares.ReadSoftwaresXml(otherdevice.Softwares);
            extras.ReadExtras(otherdevice.Extras);
            PriceTextBox.Text = otherdevice.Price.ToString();
            CodeTextBox.Text = otherdevice.DeviceInformationCode;
        }
        private void ExcuteUpdateButtonClickOtherDevice(object sender, RoutedEventArgs e)
        {
            otherdevice.CustomerName = NameTextBox.Text;
            otherdevice.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            otherdevice.DeviceCompany = DeviceCompanyTextBox.Text;
            otherdevice.Model = ModelTextBox.Text;
            otherdevice.SerialNumber = SerialNumberTextBox.Text;
            otherdevice.Extras = extras.WriteExtras();
            otherdevice.Hardwares = hardwares.WriteHardwaresXml();
            otherdevice.Softwares = softwares.WriteSoftwaresXml();
            otherdevice.Status = otherdevice.setStatus();
            otherdevice.Price = otherdevice.sumDevicePartsPrice();


            try
            {
                if (OtherDeviceData.UpdateOtherDevice(otherdevice) == true)
                {
                    SetMassage("Update is completed");
                    SetMassageBackground(Brushes.LimeGreen);
                    PriceTextBox.Text = otherdevice.Price.ToString();
                }
                else
                {
                    SetMassage("Update is failed");
                    SetMassageBackground(Brushes.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR |\n" + ex.Message);
                SetMassage("Update is failed");
                SetMassageBackground(Brushes.Red);
            }
            ClearFields();
            OtherDeviceData.LoadOtherDevice();
        }


    }
}
