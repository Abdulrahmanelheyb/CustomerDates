using System;
using System.Windows;
using System.Windows.Input;
using BusinessLayer;

namespace CustomerDates
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        


        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLogin.CheckUser(usertbx.Text, Passtbx.Password) == true)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR | Login\n" + ex.Message);
            }
            
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void recmovelogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void NDbtnexitlogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CheckLogin.CheckUser(usertbx.Text, Passtbx.Password) == true)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
        }

    }
}
