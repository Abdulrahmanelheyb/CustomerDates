using CustomerDates;
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
            MenuPanel.Visibility = Visibility.Collapsed;
            MenuRectangle.Visibility = Visibility.Collapsed;
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

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPanel.Visibility == Visibility.Collapsed)
            {
                MenuPanel.Visibility = Visibility.Visible;
                MenuRectangle.Visibility = Visibility.Visible;
            }
            else
            {
                MenuPanel.Visibility = Visibility.Collapsed;
                MenuRectangle.Visibility = Visibility.Collapsed;
            }

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
            CDevicesListAndControlsView uccomputers = new CDevicesListAndControlsView(CDevicesListAndControlsView.CDeviceType.Computer);
            SetUserControl(Viewgrid,uccomputers);
            ComputersList.Background = Brushes.White;
            ComputersList.Foreground = Brushes.Black;

            LaptopsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            LaptopsList.Foreground = Brushes.White;
            MobilesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            MobilesList.Foreground = Brushes.White;
            TabletsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            TabletsList.Foreground = Brushes.White;
            OtherDevicesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            OtherDevicesList.Foreground = Brushes.White;

        }
        private void Laptops_Click(object sender, RoutedEventArgs e)
        {
            CDevicesListAndControlsView uclaptops = new CDevicesListAndControlsView(CDevicesListAndControlsView.CDeviceType.Laptop);
            SetUserControl(Viewgrid, uclaptops);
            LaptopsList.Background = Brushes.White;
            LaptopsList.Foreground = Brushes.Black;

            ComputersList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            ComputersList.Foreground = Brushes.White;
            MobilesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            MobilesList.Foreground = Brushes.White;
            TabletsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            TabletsList.Foreground = Brushes.White;
            OtherDevicesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            OtherDevicesList.Foreground = Brushes.White;

        }

        private void Mobiles_Click(object sender, RoutedEventArgs e)
        {
            CDevicesListAndControlsView ucmobiles = new CDevicesListAndControlsView(CDevicesListAndControlsView.CDeviceType.Mobile);
            SetUserControl(Viewgrid, ucmobiles);
            MobilesList.Background = Brushes.White;
            MobilesList.Foreground = Brushes.Black;

            ComputersList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            ComputersList.Foreground = Brushes.White;
            LaptopsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            LaptopsList.Foreground = Brushes.White;
            TabletsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            TabletsList.Foreground = Brushes.White;
            OtherDevicesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            OtherDevicesList.Foreground = Brushes.White;
        }

        private void Tablets_Click(object sender, RoutedEventArgs e)
        {
            CDevicesListAndControlsView uctablets = new CDevicesListAndControlsView(CDevicesListAndControlsView.CDeviceType.Tablet);
            SetUserControl(Viewgrid, uctablets);
            TabletsList.Background = Brushes.White;
            TabletsList.Foreground = Brushes.Black;

            ComputersList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            ComputersList.Foreground = Brushes.White;
            LaptopsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            LaptopsList.Foreground = Brushes.White;
            MobilesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            MobilesList.Foreground = Brushes.White;
            OtherDevicesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            OtherDevicesList.Foreground = Brushes.White;
        }

        private void OtherDevices_Click(object sender, RoutedEventArgs e)
        {
            CDevicesListAndControlsView ucotherdevices = new CDevicesListAndControlsView(CDevicesListAndControlsView.CDeviceType.OtherDevice);
            SetUserControl(Viewgrid, ucotherdevices);
            OtherDevicesList.Background = Brushes.White;
            OtherDevicesList.Foreground = Brushes.Black;

            ComputersList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            ComputersList.Foreground = Brushes.White;
            LaptopsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            LaptopsList.Foreground = Brushes.White;
            MobilesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            MobilesList.Foreground = Brushes.White;
            TabletsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            TabletsList.Foreground = Brushes.White;
        }



        #endregion

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            ComputersList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            ComputersList.Foreground = Brushes.White;
            LaptopsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            LaptopsList.Foreground = Brushes.White;
            MobilesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            MobilesList.Foreground = Brushes.White;
            TabletsList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            TabletsList.Foreground = Brushes.White;
            OtherDevicesList.Background = new SolidColorBrush(Color.FromRgb(5, 0, 89));
            OtherDevicesList.Foreground = Brushes.White;
            Viewgrid.Children.Clear();
        }

        private void ToolsButton_Click(object sender, RoutedEventArgs e)
        {
            ToolsButton.Background = Brushes.White;
            ToolsButton.Foreground = Brushes.Black;
            ToolsButton.BorderThickness = new Thickness(0, 0, 0, 0);

            PreferencesButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            PreferencesButton.Foreground = Brushes.White;
            ContactButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ContactButton.Foreground = Brushes.White;
            AboutButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            AboutButton.Foreground = Brushes.White;
        }

        private void PreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            PreferencesButton.Background = Brushes.White;
            PreferencesButton.Foreground = Brushes.Black;
            PreferencesButton.BorderThickness = new Thickness(0, 0, 0, 0);

            ToolsButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ToolsButton.Foreground = Brushes.White;
            ContactButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ContactButton.Foreground = Brushes.White;
            AboutButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            AboutButton.Foreground = Brushes.White;
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactButton.Background = Brushes.White;
            ContactButton.Foreground = Brushes.Black;
            ContactButton.BorderThickness = new Thickness(0, 0, 0, 0);

            ToolsButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ToolsButton.Foreground = Brushes.White;
            PreferencesButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            PreferencesButton.Foreground = Brushes.White;
            AboutButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            AboutButton.Foreground = Brushes.White;
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutButton.Background = Brushes.White;
            AboutButton.Foreground = Brushes.Black;
            AboutButton.BorderThickness = new Thickness(0, 0, 0, 0);

            ToolsButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ToolsButton.Foreground = Brushes.White;
            PreferencesButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            PreferencesButton.Foreground = Brushes.White;
            ContactButton.Background = new SolidColorBrush(Color.FromRgb(7, 0, 119));
            ContactButton.Foreground = Brushes.White;
        }

    }
}
