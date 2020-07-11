using CustomerDates;
using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomerDates.DeviceControls.Computers
{
    // Don't forget add print fuatures for give code to customer.
    /// </summary>
    ///SolidColorBrush((Color)ColorConverter.ConvertFormString("#0000FF"));
    public partial class InsertComputerMG : Window
    {
        private Computer computer;
        public InsertComputerMG()
        {
            InitializeComponent();
            statustogglelistcreator();
        }
        List<ToggleButton> statustoggles = new List<ToggleButton>();

        

        private void SetStatus(string massage)
        {
            OperationStatus.Content = massage;
        }

        private void statustogglelistcreator()
        {

            statustoggles.Add(Repairing);
            statustoggles.Add(Completed);
            statustoggles.Add(Failed);
        }

        #region Basics
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
            if (Softwareuc.Visibility == Visibility.Visible)
            {
                Softwareuc.Visibility = Visibility.Hidden;
                softwaretab.Background = new SolidColorBrush(Color.FromRgb(51, 46, 128));
                softwaretab.Foreground = Brushes.White;
            }
            if (Hardwareuc.SetDevice(computer) == true)
            {
                Hardwareuc.Visibility = Visibility.Visible;
                hardwaretab.Background = Brushes.White;
                hardwaretab.Foreground = Brushes.Black;
            }
            else
            {
                SetStatus("To Add Hardware Info Please First Create Computer");
            }
        }

        private void softwaretab_Click(object sender, RoutedEventArgs e)
        {
            if (Hardwareuc.Visibility == Visibility.Visible)
            {
                Hardwareuc.Visibility = Visibility.Hidden;
                hardwaretab.Background = new SolidColorBrush(Color.FromRgb(51, 46, 128));
                hardwaretab.Foreground = Brushes.White;
            }

            if (Softwareuc.SetDevice(computer) == true)
            {
                Softwareuc.Visibility = Visibility.Visible;
                softwaretab.Background = Brushes.White;
                softwaretab.Foreground = Brushes.Black;
            }
            else
            {
                SetStatus("To Add Software Info Please First Create Computer");
            }

            



        }
        #endregion
        #region Window Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //hardwaretab.IsEnabled = false;
            //softwaretab.IsEnabled = false;
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
                computer = null;
                
                //.....
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
            if (computer is null == false)
            {
                SetStatus("For Create New Computer Please Press ESC To Empty Fields And Computer's Mold");
                return;
            }
            computer = new Computer();
            computer.CustomerName = NameTextBox.Text;
            computer.CustomerPhoneNumber = PhoneNumberTextBox.Text;
            computer.DeviceCompany = DeviceCompanyTextBox.Text;
            computer.Model = ModelTextBox.Text;
            computer.SerialNumber = SerialNumberTextBox.Text;
            computer.Date = DateTime.Now;
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
                computer.Price = computer.SumDevicePartsPrice();
                if (ComputerData.InsertComputer(computer) == true)
                {
                    OperationStatus.Content = "Insert is completed";
                }
                else
                {
                    OperationStatus.Content = "Insert is failed";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR |\n" + ex.Message);
            }
            ComputerData.LoadComputer();
            
        }

        #region Hardware And Software User Conrols Commands
        
        #endregion


    }
}
