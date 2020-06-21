using System;
using System.Windows;
using System.Windows.Input;
using CustomerDates.Classes;

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

        int attempt = 0;

        private void CheckUserIsCorrect()
        {
            if (DataManagment.users[0] == userbx.Text)
            {
                if (DataManagment.pwds[0] == Passbx.Password)
                {
                    MainWindow mw = new MainWindow();
                    this.Close();
                    mw.Show();
                }
                else
                {
                    attempt++;
                    MessageBox.Show("Password Is False Can Try Only 3 Attempts");
                    if (attempt == 3)
                    {
                        MessageBox.Show("You Tried 3 Attempt the program is locked !");
                        Environment.Exit(0);
                    }
                }
            }

            if (DataManagment.users[1] == userbx.Text)
            {
                if (DataManagment.pwds[1] == Passbx.Password)
                {
                    MainWindow mw = new MainWindow();
                    this.Close();
                    mw.Show();
                }
                else
                {
                    attempt++;
                    MessageBox.Show("Password Is False Can Try Only 3 Attempts");
                    if (attempt == 3)
                    {
                        MessageBox.Show("You Tried 3 Attempt the program is locked !");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            CheckUserIsCorrect();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadScreen los = new LoadScreen();
            los.Close();
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
                CheckUserIsCorrect();
            }
        }

    }
}
