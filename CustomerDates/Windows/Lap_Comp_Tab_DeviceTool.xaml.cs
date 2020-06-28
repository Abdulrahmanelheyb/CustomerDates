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
            
        }

        private void External_parts_cmbbx_LostFocus(object sender, RoutedEventArgs e)
        {
            int indx = 0;
            foreach (CheckBox cb in External_parts_cmbbx.Items)
            {
                if (cb.IsChecked == true)
                {
                   
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

           
        }


        
        #endregion

        

        

        

        #region Software & Hardware Methods >>>>>

        private void Addhwarepart(string tbname)
        {
           
        }
        private void Addswarepart(string tbname)
        {
           
        }
        private void Add_info_Click(object sender, RoutedEventArgs e)
        {
          
        }


        private void Updatehwarepart(string tbname)
        {
           
        }

        private void Update_info_Click(object sender, RoutedEventArgs e)
        {
         
        }
        private void Delete_info_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Hardwaretab_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Softwaretab_Click(object sender, RoutedEventArgs e)
        {
           
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
            
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }







        #endregion

        #endregion

        
    }
}
