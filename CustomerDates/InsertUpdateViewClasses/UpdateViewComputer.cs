using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.ComputerServices;
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
        public void UpdateViewComputer()
        {
            Execute_btn.Click += ExcuteUpdateButtonClickComputer;
            ExtrasRow.Height = new GridLength(0);
        }

        public void SetComputer(Computer computer)
        {
            this.computer = computer;
            NameTextBox.Text = computer.CustomerName;
            PhoneNumberTextBox.Text = computer.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = computer.DeviceCompany;
            ModelTextBox.Text = computer.Model;
            SerialNumberTextBox.Text = computer.SerialNumber;
            hardwares.ReadHardwaresXml(computer.Hardwares);
            softwares.ReadSoftwaresXml(computer.Softwares);
            PriceTextBox.Text = computer.Price.ToString();
            CodeTextBox.Text = computer.DeviceInformationCode;
        }


        private void ExcuteUpdateButtonClickComputer(object sender, RoutedEventArgs e)
        {
            computer.CustomerName = NameTextBox.Text;
            computer.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            computer.DeviceCompany = DeviceCompanyTextBox.Text;
            computer.Model = ModelTextBox.Text;
            computer.SerialNumber = SerialNumberTextBox.Text;
            computer.DeviceInformationCode = CodeTextBox.Text;
            computer.Hardwares = hardwares.WriteHardwaresXml();
            computer.Softwares = softwares.WriteSoftwaresXml();
            computer.Status = computer.setStatus();
            computer.Price = computer.sumDevicePartsPrice();
            try
            {
                if(ComputerData.UpdateComputer(computer) == true)
                {
                    SetMassage("Update is completed");
                    SetMassageBackground(Brushes.LimeGreen);
                    PriceTextBox.Text = computer.Price.ToString();
                }
                else
                {
                    SetMassage("Update is failed");
                    SetMassageBackground(Brushes.Red);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR | UPDATE\n" + ex.Message);
                SetMassage("Update is failed");
                SetMassageBackground(Brushes.Red);
            }
            ClearFields();
            ComputerData.LoadComputer();
        }

    }
}
