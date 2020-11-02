using CustomerDates.ViewModel.LaptopServices;
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
        public void UpdateViewMobile()
        {
            Execute_btn.Click += ExcuteUpdateButtonClickMobile;
        }

        public void SetMobile(Mobile mobile)
        {
            this.mobile = mobile;
            NameTextBox.Text = mobile.CustomerName;
            PhoneNumberTextBox.Text = mobile.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = mobile.DeviceCompany;
            ModelTextBox.Text = mobile.Model;
            SerialNumberTextBox.Text = mobile.SerialNumber;
            hardwares.ReadHardwaresXml(mobile.Hardwares);
            softwares.ReadSoftwaresXml(mobile.Softwares);
            extras.ReadExtras(mobile.Extras);
            PriceTextBox.Text = mobile.Price.ToString();
            CodeTextBox.Text = mobile.DeviceInformationCode;
        }
        private void ExcuteUpdateButtonClickMobile(object sender, RoutedEventArgs e)
        {
            mobile.CustomerName = NameTextBox.Text;
            mobile.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            mobile.DeviceCompany = DeviceCompanyTextBox.Text;
            mobile.Model = ModelTextBox.Text;
            mobile.SerialNumber = SerialNumberTextBox.Text;
            mobile.Extras = extras.WriteExtras();
            mobile.Hardwares = hardwares.WriteHardwaresXml();
            mobile.Softwares = softwares.WriteSoftwaresXml();
            mobile.Status = mobile.setStatus();
            mobile.Price = mobile.sumDevicePartsPrice();

            try
            {
                if (MobileData.UpdateMobile(mobile) == true)
                {
                    SetMassage("Update is completed");
                    SetMassageBackground(Brushes.LimeGreen);
                    PriceTextBox.Text = mobile.Price.ToString();
                }
                else
                {
                    SetMassage("Update is failed");
                    SetMassageBackground(Brushes.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR UPDATE|\n" + ex.Message);
                SetMassage("Update is failed");
                SetMassageBackground(Brushes.Red);
            }
            ClearFields();
            MobileData.LoadMobile();
        }


    }
}
