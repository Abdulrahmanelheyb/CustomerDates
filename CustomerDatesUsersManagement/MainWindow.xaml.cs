using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CustomerDatesUsersManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadusers()
        {
            Users.LoadUsers();
            user1.Text = Users.dt.Rows[0][1].ToString();
            user2.Text = Users.dt.Rows[1][1].ToString();

            pwd1.Text = Users.dt.Rows[0][2].ToString();
            pwd2.Text = Users.dt.Rows[1][2].ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadusers();
        }

        private void update1_Click(object sender, RoutedEventArgs e)
        {
            Users.UserID = Users.dt.Rows[0][0].ToString();
            if(user1.Text != null && user1.Text != "")
            {
                Users.Username = user1.Text;
            }else
            {
                MessageBox.Show("Not Can Leave User Name Is Empty !");
                return;
            }

            if (pwd1.Text != null && pwd1.Text != "")
            {
                Users.Password = pwd1.Text;
            }
            else
            {
                MessageBox.Show("Not Can Leave Password Is Empty !");
                return;
            }
            
            Users.UpdateUsers();
        }

        private void update2_Click(object sender, RoutedEventArgs e)
        {
            Users.UserID = Users.dt.Rows[1][0].ToString();
            if (user2.Text != null && user2.Text != "")
            {
                Users.Username = user2.Text;
            }
            else
            {
                MessageBox.Show("Not Can Leave User Name Is Empty !");
                return;
            }

            if (pwd2.Text != null && pwd2.Text != "")
            {
                Users.Password = pwd2.Text;
            }
            else
            {
                MessageBox.Show("Not Can Leave Password Is Empty !");
                return;
            }

            Users.UpdateUsers();
            loadusers();
        }
    }
}
