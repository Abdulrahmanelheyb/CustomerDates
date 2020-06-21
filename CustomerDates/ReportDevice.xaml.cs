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

            RaportDate.Content ="Date : "+ DateTime.Now;
            if (CheckBooleans.b_computer == true)
            {
                DataManagment.Execute(Globals.Tablename.Computers.ToString(), ReportVars.Selectedvalue);
                if(CheckBooleans.execute_select == true)
                {
                    pr_name.Content = Globals.cdname;
                    pr_phone.Content = Globals.cdphone;
                    pr_devcomp.Content = Globals.cddevicecompany;
                    pr_model.Content = Globals.cdmodel;
                    pr_sn.Content = Globals.serialnumber;
                    pr_code.Content = Globals.infoprencode;
                    pr_price.Content = Globals.cdprice;
                    //pr_external.Content = Globals.cdexternal; coming soon >>>                   
                    pr_date.Content = Globals.cddate;
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                    hardware_grd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Computers_SWareinfo.ToString());
                    software_grd.ItemsSource = DataManagment.dtload.DefaultView;

                    #region Reset 
                    CheckBooleans.execute_select = false;
                    #endregion

                }
            }

            if (CheckBooleans.b_laptop == true)
            {
                DataManagment.Execute(Globals.Tablename.Laptops.ToString(), ReportVars.Selectedvalue);
                if (CheckBooleans.execute_select == true)
                {
                    pr_name.Content = Globals.cdname;
                    pr_phone.Content = Globals.cdphone;
                    pr_devcomp.Content = Globals.cddevicecompany;
                    pr_model.Content = Globals.cdmodel;
                    pr_sn.Content = Globals.serialnumber;
                    pr_code.Content = Globals.infoprencode;
                    pr_price.Content = Globals.cdprice;
                    //pr_external.Content = Globals.cdexternal; coming soon >>>
                    pr_date.Content = Globals.cddate;

                    #region Reset 
                    CheckBooleans.execute_select = false;
                    #endregion
                }
            }

            if (CheckBooleans.b_mobile == true)
            {
                DataManagment.Execute(Globals.Tablename.Mobiles.ToString(), ReportVars.Selectedvalue);
                if (CheckBooleans.execute_select == true)
                {
                    pr_name.Content = Globals.cdname;
                    pr_phone.Content = Globals.cdphone;
                    pr_devcomp.Content = Globals.cddevicecompany;
                    pr_model.Content = Globals.cdmodel;
                    pr_sn.Content = Globals.serialnumber;
                    pr_code.Content = Globals.infoprencode;
                    pr_price.Content = Globals.cdprice;
                    // dont forget image to future ...
                    //pr_external.Content = Globals.cdexternal; coming soon >>>
                    
                    pr_date.Content = Globals.cddate;

                    #region Reset 
                    CheckBooleans.execute_select = false;
                    #endregion
                }
            }

            if (CheckBooleans.b_tablet == true)
            {
                DataManagment.Execute(Globals.Tablename.Tablets.ToString(), ReportVars.Selectedvalue);
                if (CheckBooleans.execute_select == true)
                {
                    pr_name.Content = Globals.cdname;
                    pr_phone.Content = Globals.cdphone;
                    pr_devcomp.Content = Globals.cddevicecompany;
                    pr_model.Content = Globals.cdmodel;
                    pr_sn.Content = Globals.serialnumber;
                    pr_code.Content = Globals.infoprencode;
                    pr_price.Content = Globals.cdprice;
                    //pr_external.Content = Globals.cdexternal; coming soon >>>
                    pr_date.Content = Globals.cddate;

                    #region Reset 
                    CheckBooleans.execute_select = false;
                    #endregion
                }
            }
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
