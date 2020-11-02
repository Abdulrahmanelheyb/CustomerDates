using CustomerDates.ViewModel.LaptopServices;
using CustomerDates.ViewModel.TabletServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace CustomerDates.InsertUpdateViewClasses
{
    public partial class InsertUpdateView
    {
        public void UpdateViewTablet()
        {
            Execute_btn.Click += ExcuteUpdateButtonClickTablet;
        }

        public void SetTablet(Tablet tablet)
        {
            this.tablet = tablet;
            NameTextBox.Text = tablet.CustomerName;
            PhoneNumberTextBox.Text = tablet.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = tablet.DeviceCompany;
            ModelTextBox.Text = tablet.Model;
            SerialNumberTextBox.Text = tablet.SerialNumber;
            hardwares.ReadHardwaresXml(tablet.Hardwares);
            softwares.ReadSoftwaresXml(tablet.Softwares);
            extras.ReadExtras(tablet.Extras);
            PriceTextBox.Text = tablet.Price.ToString();
            CodeTextBox.Text = tablet.DeviceInformationCode;
        }
        private void ExcuteUpdateButtonClickTablet(object sender, RoutedEventArgs e)
        {
            tablet.CustomerName = NameTextBox.Text;
            tablet.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            tablet.DeviceCompany = DeviceCompanyTextBox.Text;
            tablet.Model = ModelTextBox.Text;
            tablet.SerialNumber = SerialNumberTextBox.Text;
            tablet.Extras = extras.WriteExtras();
            tablet.Hardwares = hardwares.WriteHardwaresXml();
            tablet.Softwares = softwares.WriteSoftwaresXml();
            tablet.Price = tablet.sumDevicePartsPrice();
            tablet.Status = tablet.setStatus();

            try
            {
                if (TabletData.UpdateTablet(tablet) == true)
                {
                    SetMassage("Update is completed");
                    SetMassageBackground(Brushes.LimeGreen);
                    PriceTextBox.Text = tablet.Price.ToString();
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
            TabletData.LoadTablet();
        }


    }
}
