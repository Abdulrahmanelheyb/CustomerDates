using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;

namespace CustomerDates.InsertUpdateViewClasses
{
    public partial class InsertUpdateView
    {
        
        public void InsertViewComputer()
        {
            Execute_btn.Click += ExcuteInsertButtonClickComputer;
            
            ExtrasRow.Height = new GridLength(0);
        }

        
        private void LoadComputerFeatures()
        {
            //Hardwares
             hardwares = new Hardwares();
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Case", "Case"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Motherboard", "Motherboard"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Power Supply", "PowerSupply"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Fan", "Fan"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Storage Disk", "StorageDisk"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("RAM", "RAM"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Processor (CPU)", "ProcessorCPU"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("GraphicCard (GPU)", "GraphicCardGPU"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Sound Card", "SoundCard"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Sata Cable", "SataCable"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("CDROM", "CDROM"));

            //Softwares
             softwares = new Softwares();
            SoftwareStackPanel.Children.Add(softwares.CreateSoftware("Format", "Format")); 

        }

        private void ExcuteInsertButtonClickComputer(object sender, RoutedEventArgs e)
        {
            if (computer is null == false)
            {
                SetMassage("For Create New Computer Please Press ESC To Empty Fields And Computer's Mold");
                return;
            }
            computer = new Computer
            {
                CustomerName = NameTextBox.Text,
                CustomerPhoneNumber = PhoneNumberTextBox.Text,
                DeviceCompany = DeviceCompanyTextBox.Text,
                Model = ModelTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                Date = DateTime.Now,
                Hardwares = hardwares.WriteHardwaresXml(),
                Softwares = softwares.WriteSoftwaresXml(),
                Status = computer.SetStatus()
            };

            try
            {
                computer.Price = computer.SumDevicePartsPrice();
                if (ComputerData.InsertComputer(computer) == true)
                {
                    OperationStatus.Content = "Insert is completed";
                    PriceTextBox.Text = computer.Price.ToString();
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
            ComputerData.LoadComputer();

        }


    }
}
