using CustomerDates;
using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

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
            HardwareGrid.Visibility = Visibility.Hidden;
            SoftwareGrid.Visibility = Visibility.Hidden;
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

        
        #endregion
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
            computer.Hardwares = WriteHardwaresXml();
            computer.Softwares = WriteSoftwaresXml();
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
                OperationStatus.Content = "Insert is failed";
            }
            ComputerData.LoadComputer();
            
        }

        #region Device Technics
        private void DeviceTechnics_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox Controller = ((CheckBox)sender);
            Grid gridcontrol = (Grid)DeviceTechnicsInfoGrid.FindName(Controller.Name + "Grid");
            if (gridcontrol != null)
            {
                gridcontrol.IsEnabled = true;
            }
        }
        private void DeviceTechnics_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox Controller = ((CheckBox)sender);
            Grid gridcontrol = (Grid)DeviceTechnicsInfoGrid.FindName(Controller.Name + "Grid");
            TextBox description = (TextBox)DeviceTechnicsInfoGrid.FindName(Controller.Name + "Description");
            TextBox price = (TextBox)DeviceTechnicsInfoGrid.FindName(Controller.Name + "Price");
            Ellipse status = (Ellipse)DeviceTechnicsInfoGrid.FindName(Controller.Name + "Status");
            if (gridcontrol != null)
            {
                description.Text = "";
                price.Text = "";
                status.Fill = Brushes.White;
                gridcontrol.IsEnabled = false;
            }
        }

        private void StatusEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse controller = ((Ellipse)sender);

            if (controller.Fill == Brushes.Red || controller.Fill == Brushes.White)
            {
                controller.Fill = Brushes.Yellow;
                controller.Tag = "Repairing";
                return;
            }
            if (controller.Fill == Brushes.Yellow)
            {
                controller.Fill = Brushes.Lime;
                controller.Tag = "Completed";
                return;
            }
            if (controller.Fill == Brushes.Lime)
            {
                controller.Fill = Brushes.Red;
                controller.Tag = "Failed";
                return;
            }
        }
        #region Hardware
        private void Hardware_Click(object sender, RoutedEventArgs e)
        {
            SoftwareGrid.Visibility = Visibility.Hidden;
            Software.Background = new SolidColorBrush(Color.FromRgb(28, 20, 146));
            Software.Foreground = Brushes.White;

            HardwareGrid.Visibility = Visibility.Visible;
            Hardware.Background = Brushes.White;
            Hardware.Foreground = Brushes.Black;
        }

        public string WriteHardwaresXml()
        {
            StringBuilder hardwarexml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(new StringWriter(hardwarexml));
            writer.WriteStartDocument();
            writer.WriteStartElement("Hardwares");
            int index = 1;
            while (index != HardwareGrid.Children.Count)
            {
                if (HardwareGrid.Children[index] is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)HardwareGrid.Children[index];
                    if (chkbox.IsChecked == true)
                    {
                        writer.WriteStartElement(chkbox.Name);
                        writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                        TextBox description = (TextBox)HardwareGrid.FindName(chkbox.Name + "Description");
                        writer.WriteAttributeString("Description", description.Text);
                        TextBox price = (TextBox)HardwareGrid.FindName(chkbox.Name + "Price");
                        writer.WriteAttributeString("Price",price.Text);
                        Ellipse ellipse = (Ellipse)HardwareGrid.FindName(chkbox.Name + "Status");
                        writer.WriteAttributeString("Status", ellipse.Tag.ToString());
                        writer.WriteEndElement();
                    }
                    else
                    {
                        writer.WriteStartElement(chkbox.Name);
                        writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                        writer.WriteEndElement();
                    }
                }
                index++;
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return hardwarexml.ToString();
        }
        public string WriteSoftwaresXml()
        {
            StringBuilder softwarexml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(new StringWriter(softwarexml));
            writer.WriteStartDocument();
            writer.WriteStartElement("Softwares");
            int index = 1;
            while (index != SoftwareGrid.Children.Count)
            {
                if (SoftwareGrid.Children[index] is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)SoftwareGrid.Children[index];
                    if (chkbox.IsChecked == true)
                    {
                        writer.WriteStartElement(chkbox.Name);
                        writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                        TextBox description = (TextBox)HardwareGrid.FindName(chkbox.Name + "Description");
                        writer.WriteAttributeString("Description", description.Text);
                        TextBox price = (TextBox)HardwareGrid.FindName(chkbox.Name + "Price");
                        writer.WriteAttributeString("Price", price.Text);
                        Ellipse ellipse = (Ellipse)HardwareGrid.FindName(chkbox.Name + "Status");
                        writer.WriteAttributeString("Status", ellipse.Tag.ToString());
                        writer.WriteEndElement();
                    }
                    else
                    {
                        writer.WriteStartElement(chkbox.Name);
                        writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                        writer.WriteEndElement();
                    }
                }
                index++;
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return softwarexml.ToString();
        }
        #endregion

        #region Software
        private void Software_Click(object sender, RoutedEventArgs e)
        {
            HardwareGrid.Visibility = Visibility.Hidden;
            Hardware.Background = new SolidColorBrush(Color.FromRgb(28, 20, 146));
            Hardware.Foreground = Brushes.White;

            SoftwareGrid.Visibility = Visibility.Visible;
            Software.Background = Brushes.White;
            Software.Foreground = Brushes.Black;
        }

        #endregion
        #endregion




    }
}
