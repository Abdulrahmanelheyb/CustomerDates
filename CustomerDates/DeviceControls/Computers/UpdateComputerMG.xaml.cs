using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CustomerDates.DeviceControls
{
    // Don't forget add print fuatures for give code to customer.
    /// </summary>
    ///SolidColorBrush((Color)ColorConverter.ConvertFormString("#0000FF"));
    public partial class UpdateComputerMG : Window
    {
        public UpdateComputerMG()
        {
            InitializeComponent();
            statustogglelistcreator();
        }
        List<ToggleButton> statustoggles = new List<ToggleButton>();
        private DateTime date ;
        private void statustogglelistcreator()
        {
            statustoggles.Add(Repairing);
            statustoggles.Add(Completed);
            statustoggles.Add(Failed);
        }

        public void SetComputerData(Computer computer)
        {
            NameTextBox.Text = computer.CustomerName;
            PhoneNumberTextBox.Text = computer.CustomerPhoneNumber;
            DeviceCompanyTextBox.Text = computer.DeviceCompany;
            ModelTextBox.Text = computer.Model;
            SerialNumberTextBox.Text = computer.SerialNumber;
            date = computer.Date;
            if (computer.Status == Device.StatusType.Repairing)
            {
                Repairing.IsChecked = true;
            }
            if (computer.Status == Device.StatusType.Completed)
            {
                Completed.IsChecked = true;
            }
            if (computer.Status == Device.StatusType.Failed)
            {
                Failed.IsChecked = true;
            }
            PriceTextBox.Text = computer.Price.ToString();
            CodeTextBox.Text = computer.DeviceInformationCode;
        }

        #region Window Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        
        
        #region Windows Default Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void NDbtnexit_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                NameTextBox.Text = null;
                PhoneNumberTextBox.Text = null;
                DeviceCompanyTextBox.Text = null;
                ModelTextBox.Text = null;
                SerialNumberTextBox.Text = null;
                Repairing.IsChecked = false;
                Completed.IsChecked = false;
                Failed.IsChecked = false;
                PriceTextBox.Text = null;
                CodeTextBox.Text = null;
            }
        }
        private void Recmove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        #endregion
        #endregion
        private void Excute_btn_Click(object sender, RoutedEventArgs e)
        {
            Computer computer = new Computer();
            computer.CustomerName = NameTextBox.Text;
            computer.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            computer.DeviceCompany = DeviceCompanyTextBox.Text;
            computer.Model = ModelTextBox.Text;
            computer.SerialNumber = SerialNumberTextBox.Text;
            computer.Date = date;
            computer.DeviceInformationCode = CodeTextBox.Text;
            computer.Price = computer.SumDevicePartsPrice();
            foreach (ToggleButton toggleButton in statustoggles)
            {
                if (toggleButton.IsChecked == true)
                {
                    if ((string)toggleButton.Content == Device.StatusType.Repairing.ToString())
                    {
                        computer.Status = Device.StatusType.Repairing;
                    }
                    if ((string)toggleButton.Content == Device.StatusType.Completed.ToString())
                    {
                        computer.Status = Device.StatusType.Completed;
                    }
                    if ((string)toggleButton.Content == Device.StatusType.Failed.ToString())
                    {
                        computer.Status = Device.StatusType.Failed;
                    }

                }
            }
            try
            {
                OperationStatus.Content = (ComputerData.UpdateComputer(computer) == true) ? 
                    OperationStatus.Content = "Update is Completed" : OperationStatus.Content = "Update is Failed !";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR | UPDATE\n" + ex.Message);
            }
            ComputerData.LoadComputer();
        }

        private void Repairing_Checked(object sender, RoutedEventArgs e)
        {
            Completed.IsChecked = false;
            Failed.IsChecked = false;
        }

        private void Completed_Checked(object sender, RoutedEventArgs e)
        {
            Repairing.IsChecked = false;
            Failed.IsChecked = false;
        }

        private void Failed_Checked(object sender, RoutedEventArgs e)
        {
            Repairing.IsChecked = false;
            Completed.IsChecked = false;
        }

        private void hardwaretab_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush colorBrush = new SolidColorBrush(Color.FromRgb(51, 46, 128));
            if(Softwareuc.Visibility == Visibility.Visible)
            {
                Softwareuc.Visibility = Visibility.Hidden;
                softwaretab.Background = colorBrush;
                softwaretab.Foreground = Brushes.White;
            }
            Hardwareuc.Visibility = Visibility.Visible;
            hardwaretab.Background = Brushes.White;
            hardwaretab.Foreground = Brushes.Black;
        }

        private void softwaretab_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush colorBrush = new SolidColorBrush(Color.FromRgb(51, 46, 128));
            if (Hardwareuc.Visibility == Visibility.Visible)
            {
                Hardwareuc.Visibility = Visibility.Hidden;
                hardwaretab.Background = colorBrush;
                hardwaretab.Foreground = Brushes.White;
            }

            Softwareuc.Visibility = Visibility.Visible;
            softwaretab.Background = Brushes.White;
            softwaretab.Foreground = Brushes.Black;
            


        }
    }
}
