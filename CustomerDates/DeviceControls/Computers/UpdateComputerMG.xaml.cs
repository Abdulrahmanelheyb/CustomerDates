using CustomerDates.ViewModel.ComputerServices;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

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


        #region Basics
        List<ToggleButton> statustoggles = new List<ToggleButton>();
        private DateTime date;
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
            ReadHardwaresXml(computer);
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
            computer.Hardwares = WriteHardwaresXml();
            computer.Softwares = WriteSoftwaresXml();
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
            foreach (Computer item in Computer.Computers)
            {
                if (item.DeviceInformationCode == CodeTextBox.Text)
                {
                    PriceTextBox.Text = item.Price.ToString();
                }
            }
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
            if (gridcontrol != null)
            {
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
            return hardwarexml.ToString();
        }
        public void ReadHardwaresXml(Computer computer)
        {
            if (computer.Hardwares == null)
            {
                return;
            }
            XmlReader reader = XmlReader.Create(new StringReader(computer.Hardwares));
            while (reader.Read())
            {
                CheckBox chkbox = null;
                if (reader.Name != "xml" && reader.Name != "Hardwares")
                {
                    chkbox = (CheckBox)HardwareGrid.FindName(reader.Name);
                    chkbox.IsChecked = Convert.ToBoolean(reader.GetAttribute("Availability"));
                    if (chkbox.IsChecked == true)
                    {
                        TextBox description = (TextBox)HardwareGrid.FindName(chkbox.Name + "Description");
                        description.Text = reader.GetAttribute("Description");

                        TextBox price = (TextBox)HardwareGrid.FindName(chkbox.Name + "Price");
                        price.Text = reader.GetAttribute("Price");

                        Ellipse status = (Ellipse)HardwareGrid.FindName(chkbox.Name + "Status");
                        if (reader.GetAttribute("Status") == "Repairing")
                        {
                            status.Fill = Brushes.Yellow;
                            status.Tag = "Repairing";
                        }
                        if (reader.GetAttribute("Status") == "Completed")
                        {
                            status.Fill = Brushes.Lime;
                            status.Tag = "Completed";
                        }
                        if (reader.GetAttribute("Status") == "Failed")
                        {
                            status.Fill = Brushes.Red;
                            status.Tag = "Failed";
                        }
                    }
                }
                

            }
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
        public void ReadSoftwaresXml(Computer computer)
        {
            if (computer.Softwares == null)
            {
                return;
            }
            XmlReader reader = XmlReader.Create(new StringReader(computer.Hardwares));
            while (reader.Read())
            {
                CheckBox chkbox = null;
                if (reader.Name != "xml" && reader.Name != "Hardwares")
                {
                    chkbox = (CheckBox)SoftwareGrid.FindName(reader.Name);
                    chkbox.IsChecked = Convert.ToBoolean(reader.GetAttribute("Availability"));
                    if (chkbox.IsChecked == true)
                    {
                        TextBox description = (TextBox)SoftwareGrid.FindName(chkbox.Name + "Description");
                        description.Text = reader.GetAttribute("Description");

                        TextBox price = (TextBox)SoftwareGrid.FindName(chkbox.Name + "Price");
                        price.Text = reader.GetAttribute("Price");

                        Ellipse status = (Ellipse)HardwareGrid.FindName(chkbox.Name + "Status");
                        if (reader.GetAttribute("Status") == "Repairing")
                        {
                            status.Fill = Brushes.Yellow;
                            status.Tag = "Repairing";
                        }
                        if (reader.GetAttribute("Status") == "Completed")
                        {
                            status.Fill = Brushes.Lime;
                            status.Tag = "Completed";
                        }
                        if (reader.GetAttribute("Status") == "Failed")
                        {
                            status.Fill = Brushes.Red;
                            status.Tag = "Failed";
                        }
                    }
                }
            }
        }
        #endregion
        #endregion


    }
}
