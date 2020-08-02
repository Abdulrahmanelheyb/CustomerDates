using CustomerDates.FeaturesClasses;
using CustomerDates.ViewModel.LaptopServices;
using ObjectLayer;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomerDates.InsertUpdateViewClasses
{
    public partial class InsertUpdateView
    {
        public void InsertViewLaptop()
        {
            Execute_btn.Click += ExcuteInsertButtonClickLaptop;
        }

        public void LoadLaptopFeatures()
        {
            //Hardwares
            hardwares = new Hardwares();
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Case", "Case"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Motherboard", "Motherboard"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Power Supply", "PowerSupply"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Fan", "Fan"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Storage Disk", "StorageDisk"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("RAM", "RAM"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Processor Chip (CPU)", "ProcessorCPU"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Graphic Chip (GPU)", "GraphicCardGPU"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Sound Chip", "SoundCard"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Keyboard", "Keyboard"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("Touch Pad", "TouchPad"));
            HardwareStackPanel.Children.Add(hardwares.CreateHardware("CDROM", "CDROM"));

            //Softwares
            softwares = new Softwares();
            SoftwareStackPanel.Children.Add(softwares.CreateSoftware("Format", "Format"));

            //Extras
            extras = new Extras();
            Extras.Items.Add(extras.CreateExtra("Bag", "Bag"));
            Extras.Items.Add(extras.CreateExtra("Charge Adapter", "ChargeAdapter"));
            Extras.Items.Add(extras.CreateExtra("Mouse", "Mouse"));
            Extras.Items.Add(extras.CreateExtra("CD", "CD"));
            Extras.Items.Add(extras.CreateExtra("Headphone", "Headphone"));

        }

        private void ExcuteInsertButtonClickLaptop(object sender, RoutedEventArgs e)
        {

            if (laptop is null == false)
            {
                SetMassage("For Create New Laptop Please Press \"ESC\" To Empty Fields And Laptop's Mold");
                return;
            }
            laptop = new Laptop
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
                Status = laptop.SetStatus()

            };

            try
            {
                laptop.Price = laptop.SumDevicePartsPrice();
                if (LaptopData.InsertLaptop(laptop) == true)
                {
                    OperationStatus.Content = "Insert is completed";
                    PriceTextBox.Text = laptop.Price.ToString();
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
            LaptopData.LoadLaptop();

        }

    }
}
