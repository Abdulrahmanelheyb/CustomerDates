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
    public partial class Lap_Comp_Tab_DeviceTool : Window
    {
        public Lap_Comp_Tab_DeviceTool()
        {
            InitializeComponent();
            
        }
        
        private void enableshwareinfo()
        {
            shwaregrid.IsEnabled = true;
            softwaretab.IsEnabled = true;
            softwaretab.Foreground = Brushes.White;
            hardwaretab.IsEnabled = true;
            hardwaretab.Foreground = Brushes.White;
            ptypelbl.Foreground = Brushes.White;
            statuslbl.Foreground = Brushes.White;
            descriptiontbx.Foreground = Brushes.White;
            pricetbx.Foreground = Brushes.White;
        }

        private void disableshwareinfo()
        {
            shwaregrid.IsEnabled = false;
            softwaretab.IsEnabled = false;
            softwaretab.Foreground = Brushes.LightSteelBlue;
            hardwaretab.IsEnabled = false;
            hardwaretab.Foreground = Brushes.LightSteelBlue;
            ptypelbl.Foreground = Brushes.LightSteelBlue;
            statuslbl.Foreground = Brushes.LightSteelBlue;
            descriptiontbx.Foreground = Brushes.LightSteelBlue;
            pricetbx.Foreground = Brushes.LightSteelBlue;
        }

        private void GetDeviceDataFormGlobals()
        {
            Name_tbx.Text = Globals.cdname;
            Name_tbx.Foreground = Brushes.Black;
            Phone_tbx.Text = Globals.cdphone;
            Phone_tbx.Foreground = Brushes.Black;
            Device_company_tbx.Text = Globals.cddevicecompany;
            Device_company_tbx.Foreground = Brushes.Black;
            Model_tbx.Text = Globals.cdmodel;
            Model_tbx.Foreground = Brushes.Black;
            SN_tbx.Text = Globals.serialnumber;
            SN_tbx.Foreground = Brushes.Black;
            Price_tbx.Text = Globals.cdprice;
            Price_tbx.Foreground = Brushes.Black;
            Code_tbx.Text = Globals.infoprencode;
            Code_tbx.Foreground = Brushes.Black;
            int i = 0;
            while(i != Globals.cdexternal.Length)
            {
                if(Globals.cdexternal[i] != '-')
                {
                    int inx = Convert.ToInt32(Globals.cdexternal[i].ToString());
                    Globals.externals[inx].IsChecked = true;
                }
                i++;
            }
            foreach (CheckBox c in Globals.externals)
            {
                External_parts_cmbbx.Items.Add(c);
            }
            if (Globals.statustext == Globals.cdstatus.Repairing.ToString())
            {
                status_cbx_header.Visibility = Visibility.Hidden;
                Status_cbx.SelectedIndex = 0;
            }
            else if (Globals.statustext == Globals.cdstatus.Completed.ToString())
            {
                status_cbx_header.Visibility = Visibility.Hidden;
                Status_cbx.SelectedIndex = 1;
            }
            else if (Globals.statustext == Globals.cdstatus.Failed.ToString())
            {
                status_cbx_header.Visibility = Visibility.Hidden;
                Status_cbx.SelectedIndex = 2;
            }
        }

        #region Window Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HardwareParts.ID = -1;
            SoftwareParts.ID = -1;
            if (CheckBooleans.b_computer == true)
            {
                DataManagment.SPartsEx(Globals.shpartstablename.Computer_Data.ToString());
                DataManagment.HPartsEx(Globals.shpartstablename.Computer_Data.ToString());
                External_parts_cmbbx.IsEnabled = false;
                Excute_btn.Content = PublicMainVars.Content_Text;
                LBnewdevice.Content = PublicMainVars.Content_Text + " Computer";
                if ((string)LBnewdevice.Content == "Add Computer")
                {
                    disableshwareinfo();
                }
                if ((string)LBnewdevice.Content == "Update Computer")
                {
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                    hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Computers_SWareinfo.ToString());
                    softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    GetDeviceDataFormGlobals();
                }
                
            }
            if (CheckBooleans.b_laptop == true)
            {

                DataManagment.HPartsEx(Globals.shpartstablename.Laptop_Data.ToString());
                DataManagment.SPartsEx(Globals.shpartstablename.Laptop_Data.ToString());
                CheckBox cb;
                Globals.externals.Add(cb = new CheckBox { Content = "Bag", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Mouse", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "CD", Foreground = Brushes.White });

                Excute_btn.Content = PublicMainVars.Content_Text;
                LBnewdevice.Content = PublicMainVars.Content_Text + " Laptop";

                if ((string)LBnewdevice.Content == "Add Laptop")
                {
                    disableshwareinfo();
                }

                
                if ((string)LBnewdevice.Content == "Update Laptop")
                {
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Laptops_HWareinfo.ToString());
                    hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Laptops_SWareinfo.ToString());
                    softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    GetDeviceDataFormGlobals();
                }


            }

            if (CheckBooleans.b_mobile == true)
            {
                Excute_btn.Content = PublicMainVars.Content_Text;
                LBnewdevice.Content = PublicMainVars.Content_Text + " Mobile";
                DataManagment.HPartsEx(Globals.shpartstablename.Mobile_Data.ToString());
                DataManagment.SPartsEx(Globals.shpartstablename.Mobile_Data.ToString());
                CheckBox cb;
                Globals.externals.Add(cb = new CheckBox { Content = "SD Card", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Sim Card", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Cover", Foreground = Brushes.White });

                if ((string)LBnewdevice.Content == "Add Mobile")
                {
                    disableshwareinfo();
                }

                if ((string)LBnewdevice.Content == "Update Mobile")
                {
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());
                    hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Mobiles_SWareinfo.ToString());
                    softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    GetDeviceDataFormGlobals();
                }
            }

            if (CheckBooleans.b_tablet == true)
            {

                DataManagment.HPartsEx(Globals.shpartstablename.Tablet_Data.ToString());
                DataManagment.SPartsEx(Globals.shpartstablename.Tablet_Data.ToString());                
                CheckBox cb;
                Globals.externals.Add(cb = new CheckBox { Content = "SD Card", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Sim Card", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Cover", Foreground = Brushes.White });
                Globals.externals.Add(cb = new CheckBox { Content = "Keyboard", Foreground = Brushes.White });

                Excute_btn.Content = PublicMainVars.Content_Text;
                LBnewdevice.Content = PublicMainVars.Content_Text + " Tablet";

                if ((string)LBnewdevice.Content == "Add Tablet")
                {
                    disableshwareinfo();
                }
                

                

                if ((string)LBnewdevice.Content == "Update Tablet")
                {
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Tablets_HWareinfo.ToString());
                    hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Tablets_SWareinfo.ToString());
                    softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    GetDeviceDataFormGlobals();
                }

            }

            if (CheckBooleans.b_otherdevice == true)
            {

                DataManagment.HPartsEx(Globals.shpartstablename.Otherdevices_Data.ToString());
                DataManagment.SPartsEx(Globals.shpartstablename.Otherdevices_Data.ToString());
                CheckBox Cb ;
                Globals.externals.Add(Cb = new CheckBox { Content = "SD Card", Foreground = Brushes.White });
                Globals.externals.Add(Cb = new CheckBox { Content = "Device Box", Foreground = Brushes.White });
                Globals.externals.Add(Cb = new CheckBox { Content = "Bag", Foreground = Brushes.White });

                Excute_btn.Content = PublicMainVars.Content_Text;
                LBnewdevice.Content = PublicMainVars.Content_Text + " Device";

                if ((string)LBnewdevice.Content == "Add Device")
                {
                    disableshwareinfo();
                }

                if ((string)LBnewdevice.Content == "Update Device")
                {
                    DataManagment.ExecuteParts(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());
                    hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    DataManagment.ExecuteParts(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());
                    softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    GetDeviceDataFormGlobals();
                }

            }
        }

        
        
        #region Windows Default Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void NDbtnexit_Click(object sender, RoutedEventArgs e)
        {
            Globals.externals.Clear();
            parttypecbx.Items.Clear();
            HardwareParts.parts.Clear();
            SoftwareParts.parts.Clear();
            External_parts_cmbbx.Items.Clear();
            Globals.infoprencode = null;
            this.Close();
            //reset fun
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                #region Text Reset >>>>>>>>>>>>>
                Name_tbx.Text = "Name-Surname";
                Phone_tbx.Text = "Phone Number";
                Device_company_tbx.Text = "Device Company";
                SN_tbx.Text = "S/N";
                Model_tbx.Text = "Model";
                Status_cbx.SelectedIndex = -1;
                Price_tbx.Text = "Price";
                External_parts_cmbbx.SelectedIndex = -1;
                Code_tbx.Text = "Code";
                #endregion

                #region Color Forground Reset >>>>>>>>>>>
                Name_tbx.Foreground = Brushes.Gray;
                Phone_tbx.Foreground = Brushes.Gray;
                Device_company_tbx.Foreground = Brushes.Gray;
                SN_tbx.Foreground = Brushes.Gray;
                Model_tbx.Foreground = Brushes.Gray;
                Price_tbx.Foreground = Brushes.Gray;
                Code_tbx.Foreground = Brushes.Gray;
                #endregion

                #region Focus Reset >>>>>>>>>>>>
                //Coming........
                Name_tbx.Focus();
                #endregion
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
        #region Got Focus & Lost Focus Methods >>>>>>>>>>>>>>>>>>>>>>>>>>
        private void Name_tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name_tbx.Text == "Name-Surname")
            {
                Name_tbx.Text = "";
                Name_tbx.Foreground = Brushes.Black;
            }
        }

        private void Name_tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name_tbx.Text == "")
            {
                Name_tbx.Text = "Name-Surname";
                Name_tbx.Foreground = Brushes.Gray;
            }
            Globals.cdname = Name_tbx.Text;
        }

        private void Phone_tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Phone_tbx.Text == "Phone Number")
            {
                Phone_tbx.Text = "";
                Phone_tbx.Foreground = Brushes.Black;
            }
        }

        private void Phone_tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Phone_tbx.Text == "")
            {
                Phone_tbx.Text = "Phone Number";
                Phone_tbx.Foreground = Brushes.Gray;

            }
            Globals.cdphone = Phone_tbx.Text;
        }

        private void Device_company_tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Device_company_tbx.Text == "Device Company")
            {
                Device_company_tbx.Text = "";
                Device_company_tbx.Foreground = Brushes.Black;
            }
        }

        private void Device_company_tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Device_company_tbx.Text == "")
            {
                Device_company_tbx.Text = "Device Company";
                Device_company_tbx.Foreground = Brushes.Gray;
            }
            Globals.cddevicecompany = Device_company_tbx.Text;
        }

        private void Model_tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Model_tbx.Text == "Model")
            {
                Model_tbx.Text = "";
                Model_tbx.Foreground = Brushes.Black;
            }
        }

        private void Model_tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Model_tbx.Text == "")
            {
                Model_tbx.Text = "Model";
                Model_tbx.Foreground = Brushes.Gray;
            }
            Globals.cdmodel = Model_tbx.Text;
        }

        private void SN_tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SN_tbx.Text == "S/N")
            {
                SN_tbx.Text = "";
                SN_tbx.Foreground = Brushes.Black;
            }
        }

        private void SN_tbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SN_tbx.Text == "")
            {
                SN_tbx.Text = "S/N";
                SN_tbx.Foreground = Brushes.Gray;
            }
            Globals.serialnumber = SN_tbx.Text;
        }

        private void Status_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Status_cbx.SelectedIndex == 0 || Status_cbx.SelectedIndex == 1 || Status_cbx.SelectedIndex == 2)
            {
                status_cbx_header.Visibility = Visibility.Hidden;
            }
            else
            {
                status_cbx_header.Visibility = Visibility.Visible;
            }
            Globals.statusid = Status_cbx.SelectedIndex;
        }

        private void External_parts_cmbbx_LostFocus(object sender, RoutedEventArgs e)
        {
            int indx = 0;
            foreach (CheckBox cb in External_parts_cmbbx.Items)
            {
                if (cb.IsChecked == true)
                {
                    Globals.cdexternal += "-" + indx;
                }
                indx++;
            }
        }

        private void Code_tbx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(Code_tbx.Text);
        }

        
        
        #endregion
        #region Device Data >>>>>>>>>
        private void Excute_btn_Click(object sender, RoutedEventArgs e)
        {

            if (CheckBooleans.b_computer == true)
            {

                //On Here Add Execute With Execute button content for get operation.
                if ((string)LBnewdevice.Content == "Add Computer")
                {
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                        Globals.swarepartstables.Computers_SWareinfo.ToString()).ToString();
                    // if chkd data == true of bool
                    DataManagment.Execute_InsertDevice(Globals.Tablename.Computers.ToString(),Globals.CheckDeviceData());
                    if (CheckBooleans.execute_insert == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Computer is added successfuly.";
                        enableshwareinfo();
                        return;

                    }
                    else
                    {
                        OperationStatus.Text = "Computer is add Failed !";
                        return;
                    }


                }

                if ((string)LBnewdevice.Content == "Update Computer")
                {
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                        Globals.swarepartstables.Computers_SWareinfo.ToString()).ToString();
                    DataManagment.Execute_UpdateDevice(Globals.Tablename.Computers.ToString(),Globals.CheckDeviceData());
                    if (CheckBooleans.execute_update == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Computer is updated successfuly.";
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Computer is Update Failed !";
                        return;
                    }
                }

            }

            if (CheckBooleans.b_laptop == true)
            {

                
                if ((string)LBnewdevice.Content == "Add Laptop")
                {
                    
                    
                    
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                        Globals.swarepartstables.Laptops_SWareinfo.ToString()).ToString();
                    DataManagment.Execute_InsertDevice(Globals.Tablename.Laptops.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_insert == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Laptop is added successfuly.";
                        enableshwareinfo();
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Laptop is add Failed !";
                        return;
                    }
                }

                if ((string)LBnewdevice.Content == "Update Laptop")
                {
                    
                    
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                        Globals.swarepartstables.Laptops_SWareinfo.ToString()).ToString();
                    //Device create date and device update info date

                    Globals.CheckDeviceData();
                    DataManagment.Execute_UpdateDevice(Globals.Tablename.Laptops.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_update == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Laptop is updated successfuly.";
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Laptop is Update Failed !";
                        return;
                    }
                }
            }

            if (CheckBooleans.b_mobile == true)
            {

                if ((string)LBnewdevice.Content == "Add Mobile")
                {
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                        Globals.swarepartstables.Mobiles_SWareinfo.ToString()).ToString();
                    DataManagment.Execute_InsertDevice(Globals.Tablename.Mobiles.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_insert == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Mobile is added successfuly.";
                        enableshwareinfo();
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Mobile is add failed !";
                        return;
                    }
                }

                if ((string)LBnewdevice.Content == "Update Mobile")
                {
                    //Device create date and device update info date
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                        Globals.swarepartstables.Mobiles_SWareinfo.ToString()).ToString();
                    Globals.CheckDeviceData();
                    DataManagment.Execute_UpdateDevice(Globals.Tablename.Mobiles.ToString(), Globals.CheckDeviceData());

                    if (CheckBooleans.execute_update == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Mobile is updated successfuly.";

                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Mobile is update failed !";

                        return;
                    }
                }
            }

            if (CheckBooleans.b_tablet == true)
            {

                //On Here Add Execute With Execute button content for get operation.
                if ((string)LBnewdevice.Content == "Add Tablet")
                {
                    
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(), Globals.swarepartstables.Tablets_SWareinfo.ToString()).ToString();
                    DataManagment.Execute_InsertDevice(Globals.Tablename.Tablets.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_insert == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Tablet is added successfuly.";
                        enableshwareinfo();
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Tablet is add failed !";
                        return;
                    }
                }

                if ((string)LBnewdevice.Content == "Update Tablet")
                {                    
                    //Device create date and device update info date                    
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                        Globals.swarepartstables.Tablets_SWareinfo.ToString()).ToString();
                    Globals.CheckDeviceData();
                    DataManagment.Execute_UpdateDevice(Globals.Tablename.Tablets.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_update == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Tablet is updated successfuly.";
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Tablet is update failed !";
                        return;
                    }
                }
            }

            if (CheckBooleans.b_otherdevice == true)
            {

                //On Here Add Execute With Execute button content for get operation.
                if ((string)LBnewdevice.Content == "Add Device")
                {
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                        Globals.swarepartstables.Otherdevices_SWareinfo.ToString()).ToString();
                    DataManagment.Execute_InsertDevice(Globals.Tablename.Otherdevices.ToString(), Globals.CheckDeviceData());
                    if (CheckBooleans.execute_insert == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Device is added successfuly.";
                        enableshwareinfo();
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Device is add failed !";
                        return;
                    }
                }

                if ((string)LBnewdevice.Content == "Update Device")
                {
                    //Device create date and device update info date
                    Globals.cdprice = Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                        Globals.swarepartstables.Otherdevices_SWareinfo.ToString()).ToString();
                    Globals.CheckDeviceData();
                    DataManagment.Execute_UpdateDevice(Globals.Tablename.Otherdevices.ToString(), Globals.CheckDeviceData());

                    if (CheckBooleans.execute_update == true)
                    {
                        Code_tbx.Text = Globals.infoprencode;
                        Code_tbx.Foreground = Brushes.Black;
                        OperationStatus.Text = "Device is updated successfuly.";
                        return;
                    }
                    else
                    {
                        OperationStatus.Text = "Device is update failed !";
                        return;
                    }
                }
            }
        }


        #region Comboboxes Events >>>>>>>>>>>>>>>>>
        
        
        #endregion
        #endregion

        

        

        

        #region Software & Hardware Methods >>>>>

        private void Addhwarepart(string tbname)
        {
            if (parttypecbx.SelectedIndex > -1)
            {
                int indx = parttypecbx.SelectedIndex;
                HardwareParts.Parttype = HardwareParts.parts[indx].Content.ToString();
            }
            else { MessageBox.Show("Please Select Part Type"); return; }
            if (descriptiontbx.Text != "Description" && descriptiontbx.Text != "")
            {
                HardwareParts.Description = descriptiontbx.Text;
            }
            else
            {
                HardwareParts.Description = null;
            }
            if (pricetbx.Text != "Price" && pricetbx.Text != "")
            {
                try
                {
                    HardwareParts.Price = Convert.ToInt32(pricetbx.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Only Number", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (statuscbx.SelectedIndex != -1)
            {
                if (statuscbx.SelectedIndex == 0)
                {
                    HardwareParts.Status = Globals.cdstatus.Repairing.ToString();
                }
                if (statuscbx.SelectedIndex == 1)
                {
                    HardwareParts.Status = Globals.cdstatus.Completed.ToString();
                }
                if (statuscbx.SelectedIndex == 2)
                {
                    HardwareParts.Status = Globals.cdstatus.Failed.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please Select Status");
                return;
            }


            DataManagment.Execute_InsertPart(tbname);
        }
        private void Addswarepart(string tbname)
        {
            if (parttypecbx.SelectedIndex > -1)
            {
                int indx = parttypecbx.SelectedIndex;
                SoftwareParts.Parttype = SoftwareParts.parts[indx].Content.ToString();
            }
            else { MessageBox.Show("Please Select Part Type"); return; }
            if (descriptiontbx.Text != "Description" && descriptiontbx.Text != "")
            {
                SoftwareParts.Description = descriptiontbx.Text;
            }
            else
            {
                SoftwareParts.Description = null;
            }
            if (pricetbx.Text != "Price" && pricetbx.Text != "")
            {
                try
                {
                    SoftwareParts.Price = Convert.ToInt32(pricetbx.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Only Number", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (statuscbx.SelectedIndex != -1)
            {
                if (statuscbx.SelectedIndex == 0)
                {
                    SoftwareParts.Status = Globals.cdstatus.Repairing.ToString();
                }
                if (statuscbx.SelectedIndex == 1)
                {
                    SoftwareParts.Status = Globals.cdstatus.Completed.ToString();
                }
                if (statuscbx.SelectedIndex == 2)
                {
                    SoftwareParts.Status = Globals.cdstatus.Failed.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please Select Status");
                return;
            }

            DataManagment.Execute_InsertPart(tbname);
        }
        private void Add_info_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.hwaretab == true)
            {
                if (HardwareParts.ID < 0)
                {
                    if (CheckBooleans.b_computer == true)
                    {
                        Addhwarepart(Globals.hwarepartstables.Computers_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                            Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_laptop == true)
                    {
                        Addhwarepart(Globals.hwarepartstables.Laptops_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                            Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Laptops_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_mobile == true)
                    {
                        Addhwarepart(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                            Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_tablet == true)
                    {
                        Addhwarepart(Globals.hwarepartstables.Tablets_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                            Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Tablets_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_otherdevice == true)
                    {
                        Addhwarepart(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                            Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }else
                {
                    MessageBox.Show("Not Can Add Update Requested Item Values");
                    return;
                }
                
            }


            if (CheckBooleans.swarretab == true)
            {
                if (SoftwareParts.ID < 0)
                {


                    if (CheckBooleans.b_computer == true)
                    {
                        Addswarepart(Globals.swarepartstables.Computers_SWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                            Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Computers_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_laptop == true)
                    {
                        Addswarepart(Globals.swarepartstables.Laptops_SWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                            Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Laptops_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_mobile == true)
                    {
                        Addswarepart(Globals.swarepartstables.Mobiles_SWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                            Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Mobiles_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_tablet == true)
                    {
                        Addswarepart(Globals.swarepartstables.Tablets_SWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                            Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Tablets_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_otherdevice == true)
                    {
                        Addswarepart(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                            Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }
                else
                {
                    MessageBox.Show("Not Can Add  Requested Item Values For Updating ,\n for add please Right Click On Mouse");
                    return;
                }
            }
            Price_tbx.Text = Globals.cdprice;
        }


        private void Updatehwarepart(string tbname)
        {
            if (parttypecbx.SelectedIndex > -1)
            {
                int indx = parttypecbx.SelectedIndex;
                HardwareParts.Parttype = HardwareParts.parts[indx].Content.ToString();
            }
            else { MessageBox.Show("Please Select Part Type"); return; }
            if (descriptiontbx.Text != "Description" && descriptiontbx.Text != "")
            {
                HardwareParts.Description = descriptiontbx.Text;
            }
            else
            {
                HardwareParts.Description = null;
            }
            if (pricetbx.Text != "Price" && pricetbx.Text != "")
            {
                try
                {
                    HardwareParts.Price = Convert.ToInt32(pricetbx.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Only Number", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (statuscbx.SelectedIndex != -1)
            {
                if (statuscbx.SelectedIndex == 0)
                {
                    HardwareParts.Status = Globals.cdstatus.Repairing.ToString();
                }
                if (statuscbx.SelectedIndex == 1)
                {
                    HardwareParts.Status = Globals.cdstatus.Completed.ToString();
                }
                if (statuscbx.SelectedIndex == 2)
                {
                    HardwareParts.Status = Globals.cdstatus.Failed.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please Select Status");
                return;
            }
            DataManagment.Execute_UpdatePart(tbname);
        }
        private void Updateswarepart(string tbname)
        {
            
            if (parttypecbx.SelectedIndex > -1)
            {
                int indx = parttypecbx.SelectedIndex;
                SoftwareParts.Parttype = SoftwareParts.parts[indx].Content.ToString();
            }
            else { MessageBox.Show("Please Select Part Type"); return; }
            if (descriptiontbx.Text != "Description" && descriptiontbx.Text != "")
            {
                SoftwareParts.Description = descriptiontbx.Text;
            }
            else
            {
                SoftwareParts.Description = null;
            }
            if (pricetbx.Text != "Price" && pricetbx.Text != "")
            {
                try
                {
                    SoftwareParts.Price = Convert.ToInt32(pricetbx.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Only Number", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (statuscbx.SelectedIndex != -1)
            {
                if (statuscbx.SelectedIndex == 0)
                {
                    SoftwareParts.Status = Globals.cdstatus.Repairing.ToString();
                }
                if (statuscbx.SelectedIndex == 1)
                {
                    SoftwareParts.Status = Globals.cdstatus.Completed.ToString();
                }
                if (statuscbx.SelectedIndex == 2)
                {
                    SoftwareParts.Status = Globals.cdstatus.Failed.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please Select Status");
                return;
            }

            DataManagment.Execute_UpdatePart(tbname);
        }

        private void Update_info_Click(object sender, RoutedEventArgs e)
        {
            if(CheckBooleans.hwaretab == true)
            {
                if (HardwareParts.ID != -1)
                {
                    if (CheckBooleans.b_computer == true)
                    {
                        Updatehwarepart(Globals.hwarepartstables.Computers_HWareinfo.ToString());                        
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                            Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_laptop == true)
                    {
                        Updatehwarepart(Globals.hwarepartstables.Laptops_HWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                            Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Laptops_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_mobile == true)
                    {
                        Updatehwarepart(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                            Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_tablet == true)
                    {
                        Updatehwarepart(Globals.hwarepartstables.Tablets_HWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                            Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Tablets_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_otherdevice == true)
                    {
                        Updatehwarepart(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                            Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }
            }


            if (CheckBooleans.swarretab == true)
            {
                if (SoftwareParts.ID != -1)
                {
                    if (CheckBooleans.b_computer == true)
                    {
                        Updateswarepart(Globals.swarepartstables.Computers_SWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                            Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Computers_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_laptop == true)
                    {
                        Updateswarepart(Globals.swarepartstables.Laptops_SWareinfo.ToString());                      
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                            Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Laptops_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_mobile == true)
                    {
                        Updateswarepart(Globals.swarepartstables.Mobiles_SWareinfo.ToString());                       
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                            Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Mobiles_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_tablet == true)
                    {
                        Updateswarepart(Globals.swarepartstables.Tablets_SWareinfo.ToString());                      
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                            Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Tablets_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    if (CheckBooleans.b_otherdevice == true)
                    {
                        Updateswarepart(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());                      
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                            Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }
            }
            Price_tbx.Text = Globals.cdprice;
        }
        private void Delete_info_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBooleans.hwaretab == true)
            {
                if(CheckBooleans.b_computer == true)
                {
                    DataRowView rowv = hardwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        HardwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteHPart(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                        Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Computers_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if(CheckBooleans.b_laptop == true)
                {
                    DataRowView rowv = hardwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        HardwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteHPart(Globals.hwarepartstables.Laptops_HWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                        Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Laptops_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if(CheckBooleans.b_mobile == true)
                {
                    DataRowView rowv = hardwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        HardwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteHPart(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                        Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Mobiles_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if(CheckBooleans.b_tablet == true)
                {
                    DataRowView rowv = hardwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        HardwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteHPart(Globals.hwarepartstables.Tablets_HWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                        Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Tablets_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if(CheckBooleans.b_otherdevice == true)
                {
                    DataRowView rowv = hardwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        HardwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteHPart(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                        Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString());
                        hardwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }
                
            }
            if (CheckBooleans.swarretab == true)
            {
                if (CheckBooleans.b_computer == true)
                {
                    DataRowView rowv = softwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        SoftwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteSPart(Globals.swarepartstables.Computers_SWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Computers_HWareinfo.ToString(),
                        Globals.swarepartstables.Computers_SWareinfo.ToString()), Globals.Tablename.Computers.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Computers_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                    
                }
                if (CheckBooleans.b_laptop == true)
                {
                    DataRowView rowv = softwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        SoftwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteSPart(Globals.swarepartstables.Laptops_SWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Laptops_HWareinfo.ToString(),
                        Globals.swarepartstables.Laptops_SWareinfo.ToString()), Globals.Tablename.Laptops.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Laptops_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if(CheckBooleans.b_mobile == true)
                {
                    DataRowView rowv = softwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        SoftwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteSPart(Globals.swarepartstables.Mobiles_SWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Mobiles_HWareinfo.ToString(),
                        Globals.swarepartstables.Mobiles_SWareinfo.ToString()), Globals.Tablename.Mobiles.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Mobiles_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if (CheckBooleans.b_tablet == true)
                {
                    DataRowView rowv = softwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        SoftwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteSPart(Globals.swarepartstables.Tablets_SWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Tablets_HWareinfo.ToString(),
                        Globals.swarepartstables.Tablets_SWareinfo.ToString()), Globals.Tablename.Tablets.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Tablets_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }


                if (CheckBooleans.b_otherdevice == true)
                {
                    DataRowView rowv = softwaregrd.SelectedItem as DataRowView;
                    if (rowv != null)
                    {
                        SoftwareParts.ID = Convert.ToInt32(rowv.Row[0].ToString());
                        DataManagment.Execute_DeleteSPart(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());
                        Globals.PriceExecute(Globals.Pricesummer(Globals.hwarepartstables.Otherdevices_HWareinfo.ToString(),
                        Globals.swarepartstables.Otherdevices_SWareinfo.ToString()), Globals.Tablename.Otherdevices.ToString());
                        DataManagment.ExecuteParts(Globals.swarepartstables.Otherdevices_SWareinfo.ToString());
                        softwaregrd.ItemsSource = DataManagment.dtload.DefaultView;
                    }
                }
            }
            Price_tbx.Text = Globals.cdprice;
        }
        private void Hardwaretab_Click(object sender, RoutedEventArgs e)
        {
            softwaregrd.Visibility = Visibility.Hidden;
            SolidColorBrush mysolid = new SolidColorBrush();
            mysolid.Color = Color.FromRgb(51, 46, 128);
            softwaretab.BorderThickness = new Thickness(0, 0, 0, 0);
            softwaretab.Foreground = Brushes.White;
            softwaretab.Background = mysolid;
            CheckBooleans.swarretab = false;
            parttypecbx.Items.Clear();

            hardwaregrd.Visibility = Visibility.Visible;
            hardwaretab.Foreground = mysolid;
            hardwaretab.Background = Brushes.White;
            hardwaretab.BorderThickness = new Thickness(0, 2, 0, 0);
            CheckBooleans.hwaretab = true;
            
            foreach (ComboBoxItem cbi in HardwareParts.parts)
            {
                if((string)cbi.Content != "---")
                {
                    parttypecbx.Items.Add(cbi);
                }
                else
                {
                    Separator sr;
                    parttypecbx.Items.Add(sr = new Separator());
                }
                
            }
        }
        private void Softwaretab_Click(object sender, RoutedEventArgs e)
        {
            hardwaregrd.Visibility = Visibility.Hidden;
            SolidColorBrush Mysolid = new SolidColorBrush();
            Mysolid.Color = Color.FromRgb(51, 46, 128);
            hardwaretab.BorderThickness = new Thickness(0, 0, 0, 0);
            hardwaretab.Background = Mysolid;
            hardwaretab.Foreground = Brushes.White;
            CheckBooleans.hwaretab = false;
            parttypecbx.Items.Clear();


            softwaregrd.Visibility = Visibility.Visible;
            softwaretab.BorderThickness = new Thickness(0, 2, 0, 0);
            softwaretab.Foreground = Mysolid;
            softwaretab.Background = Brushes.White;
            CheckBooleans.swarretab = true;
            foreach (ComboBoxItem cbi in SoftwareParts.parts)
            {
                parttypecbx.Items.Add(cbi);
            }
        }

        #region partcreator elements methods
        private void descriptiontbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (descriptiontbx.Text == "Description")
            {
                descriptiontbx.Text = "";
            }
        }
        private void descriptiontbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (descriptiontbx.Text == "")
            {
                descriptiontbx.Text = "Description";
            }
        }

        private void shpricetbx_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pricetbx.Text == "")
            {
                pricetbx.Text = "Price";
            }
            if (statuscbx.SelectedIndex == 2)
            {
                pricetbx.Text = "0";
            }
        }
        private void shpricetbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pricetbx.Text == "Price")
            {
                pricetbx.Text = "";
            }
        }
        private void Parttypecbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (parttypecbx.SelectedIndex != -1)
            {
                ptypelbl.Visibility = Visibility.Hidden;
            }
            else
            {
                ptypelbl.Visibility = Visibility.Visible;
            }
        }

        private void Statuscbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (statuscbx.SelectedIndex != -1)
            {
                statuslbl.Visibility = Visibility.Hidden;
            }
            else
            {
                statuslbl.Visibility = Visibility.Visible;
            }

            if(statuscbx.SelectedIndex == 2)
            {
                pricetbx.Text = "0";
            }

        }
        #endregion

        #region SHWare DataGrid Methods
        private void DataGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            dg.SelectedIndex = -1;
            dg.SelectedItem = -1;
            parttypecbx.SelectedIndex = -1;
            descriptiontbx.Text = "Description";
            pricetbx.Text = "Price";
            statuscbx.SelectedIndex = -1;
            HardwareParts.ID = -1;
            SoftwareParts.ID = -1;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            DataRowView drv = dg.SelectedItem as DataRowView;
            if (drv != null)
            {
                if (CheckBooleans.hwaretab == true)
                {
                    HardwareParts.ID = Convert.ToInt32(drv.Row[0]);
                    Globals.infoprencode = drv.Row[1].ToString();
                    for (int i = 0; i != HardwareParts.parts.Count; i++)
                    {
                        if ((string)HardwareParts.parts[i].Content == drv.Row[2].ToString())
                        {
                            parttypecbx.SelectedIndex = i;
                        }
                    }
                    descriptiontbx.Text = drv.Row[3].ToString();
                    pricetbx.Text = drv.Row[4].ToString();
                    if (drv.Row[5].ToString() == Globals.cdstatus.Repairing.ToString())
                    {
                        statuscbx.SelectedIndex = 0;
                    }
                    if (drv.Row[5].ToString() == Globals.cdstatus.Completed.ToString())
                    {
                        statuscbx.SelectedIndex = 1;
                    }
                    if (drv.Row[5].ToString() == Globals.cdstatus.Failed.ToString())
                    {
                        statuscbx.SelectedIndex = 2;
                    }

                }

                if (CheckBooleans.swarretab == true)
                {
                    SoftwareParts.ID = Convert.ToInt32(drv.Row[0]);
                    Globals.infoprencode = drv.Row[1].ToString();
                    for (int i = 0; i != SoftwareParts.parts.Count; i++)
                    {
                        if ((string)SoftwareParts.parts[i].Content == drv.Row[2].ToString())
                        {
                            parttypecbx.SelectedIndex = i;
                        }
                    }
                    descriptiontbx.Text = drv.Row[3].ToString();
                    pricetbx.Text = drv.Row[4].ToString();
                    if (drv.Row[5].ToString() == Globals.cdstatus.Repairing.ToString())
                    {
                        statuscbx.SelectedIndex = 0;
                    }
                    if (drv.Row[5].ToString() == Globals.cdstatus.Completed.ToString())
                    {
                        statuscbx.SelectedIndex = 1;
                    }
                    if (drv.Row[5].ToString() == Globals.cdstatus.Failed.ToString())
                    {
                        statuscbx.SelectedIndex = 2;
                    }
                }
            }

        }







        #endregion

        #endregion

        
    }
}
