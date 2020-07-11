using CustomerDates;
using CustomerDates.DeviceControls.Computers;
using CustomerDates.DeviceControls.Laptops;
using CustomerDates.DeviceControls.Mobiles;
using CustomerDates.DeviceControls.OtherDevices;
using CustomerDates.DeviceControls.Tablets;
using CustomerDates.DeviceControls;
using ObjectLayer;
using System;
using System.Data;
using System.IdentityModel.Protocols.WSTrust;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CustomerDates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 

    public static class PublicMainVars
    {
        #region Update Content >>>>>>>>>>>>>>>>>>>>
        private static string Create_btn_content;

        public static string Content_Text
        {
            get { return Create_btn_content; }
            set { Create_btn_content = value; }
        }

        #endregion
    }

    

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.WorkArea.Height;
           
        }


        #region Window Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //add to list
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // This code binding key from keyboard for set window state

            if (e.Key == Key.F && Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.WindowState = WindowState.Maximized;
            }
            if (e.Key == Key.M && Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.WindowState = WindowState.Minimized;
            }
            if (e.Key == Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.Close();
            }
            if (e.Key == Key.R && Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // this for exit window
            Login log = new Login();
            this.Close();
            log.Show();



        }

        private void Minimizebtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else { this.WindowState = WindowState.Minimized; }
        }

        private void Maximizebtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else { this.WindowState = WindowState.Normal; }
        }

        private void MMbtnexit_Click(object sender, RoutedEventArgs e)
        {
            //add save warning save and cancel .
            this.Close();
        }


        #endregion

        #region TopDock events
        private void Topdock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Computers_Click(object sender, RoutedEventArgs e)
        {
            ComputersManager uccomputers = new ComputersManager();
            OperationsStatus.Content = ComputersManager.UCGetName();
            SetUserControl(Viewgrid,uccomputers);
            
        }
        private void Laptops_Click(object sender, RoutedEventArgs e)
        {
            LaptopsManager uclaptops = new LaptopsManager();
            OperationsStatus.Content = LaptopsManager.UCGetName();
            SetUserControl(Viewgrid, uclaptops);
        }

        private void Mobiles_Click(object sender, RoutedEventArgs e)
        {
            MobilesManager ucmobiles = new MobilesManager();
            OperationsStatus.Content = MobilesManager.UCGetName();
            SetUserControl(Viewgrid, ucmobiles);
        }

        private void Tablets_Click(object sender, RoutedEventArgs e)
        {
            TabletsManager uctablets = new TabletsManager();
            OperationsStatus.Content = TabletsManager.UCGetName();
            SetUserControl(Viewgrid, uctablets);
        }

        private void OtherDevices_Click(object sender, RoutedEventArgs e)
        {
            OtherDevicesManager ucotherdevices = new OtherDevicesManager();
            OperationsStatus.Content = OtherDevicesManager.UCGetName();
            SetUserControl(Viewgrid, ucotherdevices);
        }








        #endregion


    }
}
