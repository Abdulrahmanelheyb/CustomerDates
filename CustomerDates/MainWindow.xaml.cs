using CustomerDates.Pages;
using CustomerDates.Classes;
using System;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using BusinessLayer;

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
        
        private ReportDevice rd;
       
        
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.WorkArea.Height;
           
        }

        #region Window Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            #region Data Loading >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            DataManagment.Execute(Globals.Tablename.Computers.ToString());
            DataGrComp.ItemsSource = DataManagment.dtload.DefaultView;
            //set color by status text index or text by name .           


            DataManagment.Execute(Globals.Tablename.Laptops.ToString());
            DataGrLap.ItemsSource = DataManagment.dtload.DefaultView;

            DataManagment.Execute(Globals.Tablename.Mobiles.ToString());
            DataGrMob.ItemsSource = DataManagment.dtload.DefaultView;

            DataManagment.Execute(Globals.Tablename.Tablets.ToString());
            DataGrTab.ItemsSource = DataManagment.dtload.DefaultView;

            DataManagment.Execute(Globals.Tablename.Otherdevices.ToString());
            DataGrOth.ItemsSource = DataManagment.dtload.DefaultView;

            Status.Content = "Ready.";
            #endregion >>>>>>>>>>
            
            
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
        #endregion

        #region Controls Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        #region DataGrid Events >>>>>>>
        private void DataGrComp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid Dg = ((DataGrid)sender);
            Dg.SelectedIndex = -1;
            Dg.SelectedItem = -1;
        }
        private void DataGrDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            DataRowView drv = dg.SelectedItem as DataRowView;
            if (drv != null)
            {
                Globals.infoprencode = drv.Row[0].ToString();
                Globals.serialnumber = drv.Row[1].ToString();
                Globals.cdname = drv.Row[2].ToString();
                Globals.cdphone = drv[3].ToString();
                Globals.cdexternal = drv[4].ToString();
                Globals.cddevicecompany = drv.Row[5].ToString();
                Globals.cdmodel = drv.Row[6].ToString();
                Globals.cdprice = drv.Row[7].ToString();
                Globals.cddate = Convert.ToDateTime(drv.Row[8].ToString());
                Globals.statustext = drv.Row[9].ToString();
            }
        }

        #endregion
        #region Search Canvas 
        #region Got And Lost Focus >>>>>>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            if (Valuesch.Text == "Value")
            {
                Valuesch.Text = "";
                Valuesch.Foreground = Brushes.Black;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (Valuesch.Text == "")
            {
                Valuesch.Text = "Value";
                Valuesch.Foreground = Brushes.Gray;
            }
        }

        #endregion

        private void vtypecbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vtypecbx.SelectedIndex != -1)
            {
                vtypetxt.Visibility = Visibility.Hidden;
            }
        }
        private string Checkvtype()
        {
            string vtyperturn = null;

            vtypetxt.Visibility = Visibility.Hidden;
            if (vtypecbx.SelectedIndex == 0)
            {
                vtyperturn = "CD_Name";
            }

            if (vtypecbx.SelectedIndex == 1)
            {
                vtyperturn = "CD_Phone";
            }

            if (vtypecbx.SelectedIndex == 2)
            {
                vtyperturn = "CD_Model";
            }

            if (vtypecbx.SelectedIndex == 3)
            {
                vtyperturn = "Serial_Number";
            }

            if (vtypecbx.SelectedIndex == 4)
            {
                vtyperturn = "Infopren_Code";
            }
            return vtyperturn;
        }

        private void Searchexecute_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.b_computer == true)
            {
                if (Valuesch.Text != "" && Valuesch.Text != "Value")
                {
                    DataManagment.Execute(Globals.Tablename.Computers.ToString(), Checkvtype(), Valuesch.Text);
                    if (CheckBooleans.execute_search == true)
                    {
                        DataGrComp.ItemsSource = DataManagment.dtsearch.DefaultView;
                    }
                }


            }

            if (CheckBooleans.b_laptop == true)
            {
                if (Valuesch.Text != "" && Valuesch.Text != "Value")
                {
                    DataManagment.Execute(Globals.Tablename.Laptops.ToString(), Checkvtype(), Valuesch.Text);
                    if (CheckBooleans.execute_search == true)
                    {
                        DataGrComp.ItemsSource = DataManagment.dtsearch.DefaultView;
                    }
                }
            }

            if (CheckBooleans.b_mobile == true)
            {
                if (Valuesch.Text != "" && Valuesch.Text != "Value")
                {
                    DataManagment.Execute(Globals.Tablename.Mobiles.ToString(), Checkvtype(), Valuesch.Text);
                    if (CheckBooleans.execute_search == true)
                    {
                        DataGrComp.ItemsSource = DataManagment.dtsearch.DefaultView;
                    }
                }
            }

            if (CheckBooleans.b_tablet == true)
            {
                if (Valuesch.Text != "" && Valuesch.Text != "Value")
                {
                    DataManagment.Execute(Globals.Tablename.Tablets.ToString(), Checkvtype(), Valuesch.Text);
                    if (CheckBooleans.execute_search == true)
                    {
                        DataGrComp.ItemsSource = DataManagment.dtsearch.DefaultView;
                    }
                }
            }
        }

        #endregion
        #region Window Top Dock Controls >>>>>>>>>>>>>>>>

        private void Menubtn_Click(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush LGB = new LinearGradientBrush();
            if (ObjectsDock.Visibility == Visibility.Visible)
            {
                ObjectsDock.Visibility = Visibility.Hidden;
                Menudock.Visibility = Visibility.Visible;
                menubackrec.Visibility = Visibility.Visible;
                menurec.Fill = LGB;
                LGB.StartPoint = new Point(0.5, 0);
                LGB.EndPoint = new Point(0.5, 1);
                LGB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 51, 46, 128), 0.003));
                LGB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 102, 92, 255), 1));

            }
            else
            {
                ObjectsDock.Visibility = Visibility.Visible;
                Menudock.Visibility = Visibility.Hidden;
                menubackrec.Visibility = Visibility.Hidden;
                menurec.Fill = LGB;
                LGB.StartPoint = new Point(0.5, 1);
                LGB.EndPoint = new Point(0.5, 0);
                LGB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 51, 46, 128), 0.003));
                LGB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 102, 92, 255), 1));

                // Add Menu Tools On Here >>>

            }


        }

        private void Toolsdock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
            
            DataGrComp.Visibility = Visibility.Hidden;
            DataGrLap.Visibility = Visibility.Hidden;
            DataGrMob.Visibility = Visibility.Hidden;
            DataGrTab.Visibility = Visibility.Hidden;
            DataGrOth.Visibility = Visibility.Hidden;
            
            CheckBooleans.b_computer = false;
            CheckBooleans.b_laptop = false;
            CheckBooleans.b_mobile = false;
            CheckBooleans.b_tablet = false;
            Status.Content = "Home";
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.b_computer == true)
            {
                Lap_Comp_Tab_DeviceTool ADD_C = new Lap_Comp_Tab_DeviceTool();
                PublicMainVars.Content_Text = Globals.optype.Add.ToString();
                CheckBooleans.opadd = true;
                CheckBooleans.opupdate = false;
                ADD_C.ShowDialog();

                DataManagment.Execute(Globals.Tablename.Computers.ToString());
                DataGrComp.ItemsSource = DataManagment.dtload.DefaultView;

                if (CheckBooleans.execute_insert == true)
                {
                    Status.Content = "Computer Inserted Successfuly.";
                    
                }
                CheckBooleans.execute_insert = false;
            }

            if (CheckBooleans.b_laptop == true)
            {
                Lap_Comp_Tab_DeviceTool ADD_L = new Lap_Comp_Tab_DeviceTool();
                PublicMainVars.Content_Text = Globals.optype.Add.ToString();
                CheckBooleans.opadd = true;
                CheckBooleans.opupdate = false;
                ADD_L.ShowDialog();

                DataManagment.Execute(Globals.Tablename.Laptops.ToString());
                DataGrLap.ItemsSource = DataManagment.dtload.DefaultView;

                if (CheckBooleans.execute_insert == true)
                {
                    Status.Content = "Laptop Inserted Successfuly.";
                }
               
                CheckBooleans.execute_insert = false;
            }

            if (CheckBooleans.b_mobile == true)
            {
                Lap_Comp_Tab_DeviceTool ADD_M = new Lap_Comp_Tab_DeviceTool();
                PublicMainVars.Content_Text = Globals.optype.Add.ToString();
                CheckBooleans.opadd = true;
                CheckBooleans.opupdate = false;
                ADD_M.ShowDialog();

                DataManagment.Execute(Globals.Tablename.Mobiles.ToString());
                DataGrMob.ItemsSource = DataManagment.dtload.DefaultView;
                if (CheckBooleans.execute_insert == true)
                {
                    Status.Content = "Mobile Inserted Succesfuly.";
                }
                
                CheckBooleans.execute_insert = false;
            }

            if (CheckBooleans.b_tablet == true)
            {
                Lap_Comp_Tab_DeviceTool ADD_T = new Lap_Comp_Tab_DeviceTool();
                PublicMainVars.Content_Text = Globals.optype.Add.ToString();
                CheckBooleans.opadd = true;
                CheckBooleans.opupdate = false;
                ADD_T.ShowDialog();

                DataManagment.Execute(Globals.Tablename.Tablets.ToString());
                DataGrTab.ItemsSource = DataManagment.dtload.DefaultView;

                if (CheckBooleans.execute_insert == true)
                {
                    Status.Content = "Tablet Inserted Successfuly.";
                }
                
                CheckBooleans.execute_insert = false;
            }

            if (CheckBooleans.b_otherdevice == true)
            {
                Lap_Comp_Tab_DeviceTool ADD_OD = new Lap_Comp_Tab_DeviceTool();
                PublicMainVars.Content_Text = Globals.optype.Add.ToString();
                CheckBooleans.opadd = true;
                CheckBooleans.opupdate = false;
                ADD_OD.ShowDialog();

                DataManagment.Execute(Globals.Tablename.Otherdevices.ToString());
                DataGrOth.ItemsSource = DataManagment.dtload.DefaultView;

                if (CheckBooleans.execute_insert == true)
                {
                    Status.Content = "Device Inserted Successfuly.";

                }
                
                CheckBooleans.execute_insert = false;
            }

            if (CheckBooleans.b_computer == false &&
               CheckBooleans.b_laptop == false &&
               CheckBooleans.b_mobile == false &&
               CheckBooleans.b_tablet == false &&
               CheckBooleans.b_otherdevice == false)
            {
                Status.Content = "Please Select Device Type For Using Search Tool";
            }

        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.b_computer == true)
            {
                DataRowView Rowsellected = DataGrComp.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Lap_Comp_Tab_DeviceTool UPDATE_C = new Lap_Comp_Tab_DeviceTool();
                    PublicMainVars.Content_Text = Globals.optype.Update.ToString();
                    CheckBooleans.opupdate = true;
                    CheckBooleans.opadd = false;

                    UPDATE_C.ShowDialog();

                    DataManagment.Execute(Globals.Tablename.Computers.ToString());
                    DataGrComp.ItemsSource = DataManagment.dtload.DefaultView;

                    if (CheckBooleans.execute_update == true)
                    {
                        Status.Content = "Computer updated successfuly.";
                    }
                    
                    CheckBooleans.execute_update = false;
                }
                

            }

            if (CheckBooleans.b_laptop == true)
            {

                DataRowView Rowsellected = DataGrLap.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Lap_Comp_Tab_DeviceTool UPDATE_L = new Lap_Comp_Tab_DeviceTool();
                    PublicMainVars.Content_Text = Globals.optype.Update.ToString();
                    CheckBooleans.opupdate = true;
                    CheckBooleans.opadd = false;                    

                    UPDATE_L.ShowDialog();

                    DataManagment.Execute(Globals.Tablename.Laptops.ToString());
                    DataGrLap.ItemsSource = DataManagment.dtload.DefaultView;

                    if (CheckBooleans.execute_update == true)
                    {
                        Status.Content = "Laptop updated successfuly.";
                    }
                    
                    CheckBooleans.execute_update = false;
                }
            }

            if (CheckBooleans.b_mobile == true)
            {
                DataRowView Rowsellected = DataGrMob.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Lap_Comp_Tab_DeviceTool UPDATE_M = new Lap_Comp_Tab_DeviceTool();
                    PublicMainVars.Content_Text = Globals.optype.Update.ToString();
                    CheckBooleans.opupdate = true;
                    CheckBooleans.opadd = false;                    

                    UPDATE_M.ShowDialog();

                    DataManagment.Execute(Globals.Tablename.Mobiles.ToString());
                    DataGrMob.ItemsSource = DataManagment.dtload.DefaultView;

                    if (CheckBooleans.execute_update == true)
                    {
                        Status.Content = "Mobile updated successfuly.";                        
                    }
                    CheckBooleans.execute_update = false;
                    

                }
            }

            if (CheckBooleans.b_tablet == true)
            {
                DataRowView Rowsellected = DataGrTab.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Lap_Comp_Tab_DeviceTool UPDATE_T = new Lap_Comp_Tab_DeviceTool();
                    PublicMainVars.Content_Text = Globals.optype.Update.ToString();
                    CheckBooleans.opupdate = true;
                    CheckBooleans.opadd = false;                   
                    
                    UPDATE_T.ShowDialog();

                    DataManagment.Execute(Globals.Tablename.Tablets.ToString());
                    DataGrTab.ItemsSource = DataManagment.dtload.DefaultView;

                    if (CheckBooleans.execute_update == true)
                    {
                        Status.Content = "Tablet updated successfuly.";
                    }                    
                    CheckBooleans.execute_update = false;

                }
            }

            if(CheckBooleans.b_otherdevice == true)
            {
                DataRowView Rowsellected = DataGrOth.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Lap_Comp_Tab_DeviceTool UPDATE_T = new Lap_Comp_Tab_DeviceTool();
                    PublicMainVars.Content_Text = Globals.optype.Update.ToString();
                    CheckBooleans.opupdate = true;
                    CheckBooleans.opadd = false;                    
                    
                    UPDATE_T.ShowDialog();

                    DataManagment.Execute(Globals.Tablename.Otherdevices.ToString());
                    DataGrOth.ItemsSource = DataManagment.dtload.DefaultView;

                    if (CheckBooleans.execute_update == true)
                    {
                        Status.Content = "Device updated successfuly.";
                    }
                    CheckBooleans.execute_update = false;

                }
            }


            if (CheckBooleans.b_computer == false &&
               CheckBooleans.b_laptop == false &&
               CheckBooleans.b_mobile == false &&
               CheckBooleans.b_tablet == false &&
               CheckBooleans.b_otherdevice == false)
            {
                Status.Content = "Please Select Device Type For Using Update Tool";
            }

        }
        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
            // this opreation need future accepting by developing team..............
            //https://www.youtube.com/watch?v=pgdMv05xJ_o

            if (CheckBooleans.b_computer == true)
            {
                if (SearchCanvas.Visibility == Visibility.Hidden)
                {
                    ObjectsDock.Height -= 108;
                    ObjectsDock.Margin = new Thickness(0, 142, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Visible;
                }else
                {
                    ObjectsDock.Height += 108;
                    ObjectsDock.Margin = new Thickness(0, 33, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Hidden;
                    vtypecbx.SelectedIndex = -1;
                    vtypetxt.Visibility = Visibility.Visible;                    
                }
            }

            if (CheckBooleans.b_laptop == true)
            {
                if (SearchCanvas.Visibility == Visibility.Hidden)
                {
                    ObjectsDock.Height -= 108;
                    ObjectsDock.Margin = new Thickness(0, 142, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    ObjectsDock.Height += 108;
                    ObjectsDock.Margin = new Thickness(0, 33, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Hidden;
                    vtypecbx.SelectedIndex = -1;
                    vtypetxt.Visibility = Visibility.Visible;
                }
            }

            if (CheckBooleans.b_mobile == true)
            {
                if (SearchCanvas.Visibility == Visibility.Hidden)
                {
                    ObjectsDock.Height -= 108;
                    ObjectsDock.Margin = new Thickness(0, 142, 0, -0.4);
                    
                    SearchCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    ObjectsDock.Height += 108;
                    ObjectsDock.Margin = new Thickness(0, 33, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Hidden;
                    vtypecbx.SelectedIndex = -1;
                    vtypetxt.Visibility = Visibility.Visible;
                }
            }

            if (CheckBooleans.b_tablet == true)
            {
                if (SearchCanvas.Visibility == Visibility.Hidden)
                {
                    ObjectsDock.Height -= 108;
                    ObjectsDock.Margin = new Thickness(0, 142, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    ObjectsDock.Height += 108;
                    ObjectsDock.Margin = new Thickness(0, 33, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Hidden;
                    vtypecbx.SelectedIndex = -1;
                    vtypetxt.Visibility = Visibility.Visible;
                }
            }

            if (CheckBooleans.b_otherdevice == true)
            {
                if (SearchCanvas.Visibility == Visibility.Hidden)
                {
                    ObjectsDock.Height -= 108;
                    ObjectsDock.Margin = new Thickness(0, 142, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Visible;
                }
                else
                {
                    ObjectsDock.Height += 108;
                    ObjectsDock.Margin = new Thickness(0, 33, 0, -0.4);
                    SearchCanvas.Visibility = Visibility.Hidden;
                    vtypecbx.SelectedIndex = -1;
                    vtypetxt.Visibility = Visibility.Visible;
                }
            }


            if (CheckBooleans.b_computer == false &&
               CheckBooleans.b_laptop == false &&
               CheckBooleans.b_mobile == false &&
               CheckBooleans.b_tablet == false &&
               CheckBooleans.b_otherdevice == false)
            {
                Status.Content = "Please Select Device Type For Using Search Tool";
            }

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.b_computer == true)
            {
                DataRowView Rowsellected = DataGrComp.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Globals.infoprencode = Rowsellected.Row[0].ToString();
                    DataManagment.DeleteMSG(Globals.Tablename.Computers.ToString());
                    DataManagment.Execute(Globals.Tablename.Computers.ToString());
                    DataGrComp.ItemsSource = DataManagment.dtload.DefaultView;
                    Status.Content = "Computer deleted successfuly.";
                    
                }
                else
                {
                    MessageBox.Show("For delete first select device in row !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (CheckBooleans.b_laptop == true)
            {
                DataRowView Rowsellected = DataGrLap.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Globals.infoprencode = Rowsellected.Row[0].ToString();
                    DataManagment.DeleteMSG(Globals.Tablename.Laptops.ToString());
                    DataManagment.Execute(Globals.Tablename.Laptops.ToString());
                    DataGrLap.ItemsSource = DataManagment.dtload.DefaultView;
                    Status.Content = "Laptop deleted successfuly.";
                    
                }
                else
                {
                    MessageBox.Show("For delete first select device in row !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (CheckBooleans.b_mobile == true)
            {
                DataRowView Rowsellected = DataGrMob.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Globals.infoprencode = Rowsellected.Row[0].ToString();
                    DataManagment.DeleteMSG(Globals.Tablename.Mobiles.ToString());
                    DataManagment.Execute(Globals.Tablename.Mobiles.ToString());
                    DataGrMob.ItemsSource = DataManagment.dtload.DefaultView;
                    Status.Content = "Mobile deleted successfuly.";
                    
                }
                else
                {
                    MessageBox.Show("For delete first select device in row !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (CheckBooleans.b_tablet == true)
            {
                DataRowView Rowsellected = DataGrTab.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Globals.infoprencode = Rowsellected.Row[0].ToString();
                    DataManagment.DeleteMSG(Globals.Tablename.Tablets.ToString());
                    DataManagment.Execute(Globals.Tablename.Tablets.ToString());
                    DataGrTab.ItemsSource = DataManagment.dtload.DefaultView;
                    Status.Content = "Tablet deleted successfuly.";
                    
                }
                else
                {
                    MessageBox.Show("For delete first select device in row !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (CheckBooleans.b_otherdevice == true)
            {
                DataRowView Rowsellected = DataGrTab.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    Globals.infoprencode = Rowsellected.Row[0].ToString();
                    DataManagment.DeleteMSG(Globals.Tablename.Otherdevices.ToString());
                    DataManagment.Execute(Globals.Tablename.Otherdevices.ToString());
                    DataGrOth.ItemsSource = DataManagment.dtload.DefaultView;
                    Status.Content = "Device deleted successfuly.";
                    
                }
                else
                {
                    MessageBox.Show("For delete first select device in row !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (CheckBooleans.b_computer == false &&
               CheckBooleans.b_laptop == false &&
               CheckBooleans.b_mobile == false &&
               CheckBooleans.b_tablet == false &&
               CheckBooleans.b_otherdevice == false)
            {
                Status.Content = "Please Select Device Type For Using Delete Tool";
            }
            Globals.infoprencode = null;
        }
        private void Preview_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.b_computer == true)
            {
                //Check Selected Row in Computer.
                DataRowView Rowsellected = DataGrComp.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    ReportVars.Selectedvalue = Rowsellected.Row[0].ToString();
                    rd = new ReportDevice();
                    rd.Show();

                }

            }

            if (CheckBooleans.b_laptop == true)
            {
                //Check Selected Row in Laptop.
                DataRowView Rowsellected = DataGrLap.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    ReportVars.Selectedvalue = Rowsellected.Row[0].ToString();
                    rd = new ReportDevice();
                    rd.Show();
                }

            }

            if (CheckBooleans.b_mobile == true)
            {
                //Check Selected Row in Mobile.
                DataRowView Rowsellected = DataGrMob.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    ReportVars.Selectedvalue = Rowsellected.Row[0].ToString();
                    rd = new ReportDevice();
                    rd.Show();
                }

            }

            if (CheckBooleans.b_tablet == true)
            {
                //Check Selected Row in Tablet.
                DataRowView Rowsellected = DataGrTab.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    ReportVars.Selectedvalue = Rowsellected.Row[0].ToString();
                    rd = new ReportDevice();
                    rd.Show();
                }

            }

            if (CheckBooleans.b_otherdevice == true)
            {
                //Check Selected Row in Other Device.
                DataRowView Rowsellected = DataGrOth.SelectedItem as DataRowView;
                if (Rowsellected != null)
                {
                    ReportVars.Selectedvalue = Rowsellected.Row[0].ToString();
                    rd = new ReportDevice();
                    rd.Show();
                }

            }

            if (CheckBooleans.b_computer == false &&
               CheckBooleans.b_laptop == false &&
               CheckBooleans.b_mobile == false &&
               CheckBooleans.b_tablet == false &&
               CheckBooleans.b_otherdevice == false)
            {
                Status.Content = "Please Select Device Type For Using Preview & Reporting Tool";
            }
        }
        #endregion


        #region Window Standard Events Control >>>>>>>>>>>>>>>>>>>>>>>>>>>>
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

        #region Left Dock Controls >>>>>>>>>>>>
        private void Comp_Click(object sender, RoutedEventArgs e)
        {
           CheckBooleans.b_computer = MainWindowMethods.ViewControl_DataGrid(Viewgrid, DataGrComp);
        }

        private void Lap_Click(object sender, RoutedEventArgs e)
        {
            CheckBooleans.b_laptop = MainWindowMethods.ViewControl_DataGrid(Viewgrid, DataGrLap);
        }

        private void Mobi_Click(object sender, RoutedEventArgs e)
        {
           CheckBooleans.b_mobile = MainWindowMethods.ViewControl_DataGrid(Viewgrid, DataGrMob);
        }

        private void Tblet_Click(object sender, RoutedEventArgs e)
        {
            CheckBooleans.b_tablet = MainWindowMethods.ViewControl_DataGrid(Viewgrid, DataGrTab);
        }

        private void Oth_Click(object sender, RoutedEventArgs e)
        {
            CheckBooleans.b_otherdevice = MainWindowMethods.ViewControl_DataGrid(Viewgrid, DataGrOth);
        }


        #endregion

        #endregion

        

        #region Menu Controls Events >>>>>>>>>>>>>>
        private void Toolsbtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Settingsbtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Aboutbtn_Click(object sender, RoutedEventArgs e)
        {
            About abt = new About();
            abt.Show();
        }





        #endregion


    }
}
