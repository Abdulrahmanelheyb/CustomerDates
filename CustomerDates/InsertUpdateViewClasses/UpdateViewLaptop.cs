using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.LaptopServices;
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
        
        public void UpdateViewLaptop()
        {
            Execute_btn.Click += ExcuteUpdateButtonClickLaptop;
        }

        public void SetLaptop(Laptop laptop)
        {
            this.laptop = laptop;
            NameTextBox.Text = laptop.CustomerName;
            PhoneNumberTextBox.Text = laptop.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = laptop.DeviceCompany;
            ModelTextBox.Text = laptop.Model;
            SerialNumberTextBox.Text = laptop.SerialNumber;
            hardwares.ReadHardwaresXml(laptop.Hardwares);
            softwares.ReadSoftwaresXml(laptop.Softwares);
            extras.ReadExtras(laptop.Extras);
            PriceTextBox.Text = laptop.Price.ToString();
            CodeTextBox.Text = laptop.DeviceInformationCode;
        }
        private void ExcuteUpdateButtonClickLaptop(object sender, RoutedEventArgs e)
        {
            laptop.CustomerName = NameTextBox.Text;
            laptop.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            laptop.DeviceCompany = DeviceCompanyTextBox.Text;
            laptop.Model = ModelTextBox.Text;
            laptop.SerialNumber = SerialNumberTextBox.Text;
            laptop.Extras = extras.WriteExtras();
            laptop.Hardwares = hardwares.WriteHardwaresXml();
            laptop.Softwares = softwares.WriteSoftwaresXml();
            laptop.Status = laptop.SetStatus();
            laptop.Price = laptop.SumDevicePartsPrice();

            try
            {
                if (LaptopData.UpdateLaptop(laptop) == true)
                {
                    SetMassage("Update is completed");
                    PriceTextBox.Text = laptop.Price.ToString();
                }
                else
                {
                    SetMassage( "Update is failed");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR UPDATE |\n" + ex.Message);
                SetMassage("Update is failed");
            }
            LaptopData.LoadLaptop();

        }

    }
}
