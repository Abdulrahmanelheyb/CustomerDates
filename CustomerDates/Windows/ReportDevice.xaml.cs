using CustomerDates.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomerDates
{
    

    public static class ReportVars
    {
       static public string Selectedvalue { get; set; }
       

        
    }
    public partial class ReportDevice : Window
    {
        public ReportDevice()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = SystemParameters.WorkArea.Width/2;
            
            
        }

        

        #region  Window Methods 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }
        private void bormenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
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

        private void grd_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            dg.SelectedIndex = -1;
            dg.SelectedItem = -1;

        }
    }
}
