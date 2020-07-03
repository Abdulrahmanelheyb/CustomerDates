using CustomerDates.Classes;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CustomerDates
{
    // Don't forget add print fuatures for give code to customer.
    /// </summary>
    ///SolidColorBrush((Color)ColorConverter.ConvertFormString("#0000FF"));
    public partial class UpdateComputerMG : Window
    {
        public UpdateComputerMG()
        {
            InitializeComponent();
            
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
                AdditionalExternalsComboBox.SelectedIndex = -1;
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
