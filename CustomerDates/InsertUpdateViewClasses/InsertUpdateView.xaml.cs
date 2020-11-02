using CustomerDates.FeaturesClasses;
using ObjectLayer;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomerDates.InsertUpdateViewClasses
{
    // Don't forget add print fuatures for give code to customer.
    /// </summary>
    ///SolidColorBrush((Color)ColorConverter.ConvertFormString("#0000FF"));
    public partial class InsertUpdateView : Window
    {
        #region Window Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   
        private void NDbtnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClearFields()
        {
            NameTextBox.Text = null;
            PhoneNumberTextBox.Text = null;
            DeviceCompanyTextBox.Text = null;
            ModelTextBox.Text = null;
            SerialNumberTextBox.Text = null;
            PriceTextBox.Text = null;
            CodeTextBox.Text = null;
            computer = null;
            laptop = null;
            mobile = null;
            otherdevice = null;
            tablet = null;
            if (hardwares != null)
            {
                hardwares.ResetELementsValues();
            }
            if (softwares != null)
            {
                softwares.ResetELementsValues();
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

        #region Members Objects
        public Laptop laptop;
        public Computer computer;
        public Mobile mobile;
        public OtherDevice otherdevice;
        public ObjectLayer.Tablet tablet;
        Softwares softwares;
        Hardwares hardwares;
        Extras extras;
        #endregion

        public enum DeviceType { Computer, Laptop, Mobile, Tablet, OtherDevice }
        public enum OperationType { Insert, Update }
        private OperationType OperationTypeProperty {get; set;}
        public InsertUpdateView(DeviceType deviceType , OperationType operationType)
        {
            InitializeComponent();
            HardwareGrid.Visibility = Visibility.Hidden;
            SoftwareGrid.Visibility = Visibility.Hidden;
            if (deviceType == DeviceType.Computer)
            {
                LoadComputerFeatures();
                if (operationType == OperationType.Insert)
                {
                    InsertViewComputer();
                    SetHeader("Computer Insert");
                }
                if (operationType == OperationType.Update)
                {
                    UpdateViewComputer();
                    OperationTypeProperty = OperationType.Update;
                    SetHeader("Computer Update");
                }
                
            }
            if (deviceType == DeviceType.Laptop)
            {
                LoadLaptopFeatures();
                if (operationType == OperationType.Insert)
                {
                    InsertViewLaptop();
                    SetHeader("Laptop Insert");
                }
                if (operationType == OperationType.Update)
                {
                    UpdateViewLaptop();
                    OperationTypeProperty = OperationType.Update;
                    SetHeader("Laptop Update");
                }
            }

            if (deviceType == DeviceType.Mobile)
            {
                LoadMobileFeatures();
                if (operationType == OperationType.Insert)
                {
                    InsertViewMobile();
                    SetHeader("Mobile Insert");
                }
                if (operationType == OperationType.Update)
                {
                    UpdateViewMobile();
                    OperationTypeProperty = OperationType.Update;
                    SetHeader("Mobile Update");
                }
            }

            if (deviceType == DeviceType.Tablet)
            {
                LoadTabletFeatures();
                if (operationType == OperationType.Insert)
                {
                    InsertViewTablet();
                    SetHeader("Tablet Insert");
                }
                if (operationType == OperationType.Update)
                {
                    UpdateViewTablet();
                    OperationTypeProperty = OperationType.Update;
                    SetHeader("Tablet Update");
                }
            }

            if (deviceType == DeviceType.OtherDevice)
            {
                LoadOtherDeviceFeatures();
                if (operationType == OperationType.Insert)
                {
                    InsertViewOtherDevice();
                    SetHeader("Other Device Insert");
                }
                if (operationType == OperationType.Update)
                {
                    UpdateViewOtherDevice();
                    OperationTypeProperty = OperationType.Update;
                    SetHeader("Other Device Update");
                }
            }



        }


        private void SetMassageBackground(SolidColorBrush brush)
        {
            StatusBorder.Background = brush;
        }
        private async void SetMassage(string massage)
        {
            OperationStatus.Content = massage;
            await ResetOperationStatusText();
        }
        private void SetHeader(string Text)
        {
            Header.Text = Text;
        }
        public async Task ResetOperationStatusText()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            OperationStatus.Content = "";
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Color.FromRgb(102, 92, 255);
            StatusBorder.Background = color;
        }

        #region Device Technics
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
