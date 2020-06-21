using CustomerDates.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Reflection;
using System.Data.Entity;
using BusinessLayer;

namespace CustomerDates
{

    public static class CheckBooleans
    {
        
        

        #region Objects Left Menu bools >>>>>
        public static bool b_computer = false;
        public static bool b_laptop = false;
        public static bool b_mobile = false;
        public static bool b_tablet = false;
        public static bool b_otherdevice = false;
        #endregion

        #region Execute check bools >>>
        public static bool execute_insert = false;
        public static bool execute_update = false;
        public static bool execute_delete = false;
        public static bool execute_search = false;
        public static bool execute_select = false;
        #endregion

        #region Operation type bools >>>
        // this property not organized or not used in code..
        public static bool opadd = false;
        public static bool opupdate = false;
        #endregion

        #region Software & Hardware check bools
        public static bool hwaretab = false;
        public static bool swarretab = false;
        #endregion
    }
    public class Globals
    {
        #region Data Properties >>>>>>>>>>>>>>>>>>>>
        
        public static string infoprencode { get; set; }
        public static string cdname { get; set; }
        public static string cdphone { get; set; }
        public static string serialnumber { get; set; }
        public static string cddevicecompany { get; set; }
        public static string cdmodel { get; set; }
        public static string cdprice { get; set; }        
        public static DateTime cddate { get; set; }
        public static string cdexternal { get; set; }
        public enum cdstatus { Repairing, Completed, Failed }
        public static string statustext { get; set; }
        public static int statusid { get; set; }
        public enum optype { Add, Update}

        public static List<CheckBox> externals = new List<CheckBox>();

       
        

        
        
        public enum Tablename { Computers, Laptops, Mobiles, Tablets, Otherdevices };
        public enum shpartstablename { Computer_Data, Laptop_Data, Mobile_Data, Tablet_Data , Otherdevices_Data }
        public enum hwarepartstables { Computers_HWareinfo , Laptops_HWareinfo, Mobiles_HWareinfo, Tablets_HWareinfo, Otherdevices_HWareinfo }
        public enum swarepartstables { Computers_SWareinfo, Laptops_SWareinfo, Mobiles_SWareinfo, Tablets_SWareinfo, Otherdevices_SWareinfo }
        #endregion

        //static public Assembly ass = Assembly.GetExecutingAssembly();
        public const string DBPath = @"Data Source=Data\CustomerDates.sl3;Version=3;";
        
        //Password=/\E3Cli_i1l-/\l-i3/\n/\E3;
        
        public static int Pricesummer(string htbname,string stbname)
        {
            int hsum = 0;
            int ssum = 0;
            SQLiteConnection connect = new SQLiteConnection(DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT Price FROM "+ htbname+
                        " WHERE Infopren_Code='"+infoprencode+"'", connect);
                    SQLiteDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        hsum += sdr.GetInt32(0);
                    }
                    connect.Close();
                }
                
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT Price FROM " + stbname+
                        " WHERE Infopren_Code='" + infoprencode + "'", connect);
                    SQLiteDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ssum += sdr.GetInt32(0);
                    }
                    connect.Close();
                }
                


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int suming = hsum + ssum;
            cdprice = suming.ToString();
            return hsum + ssum;
        }

        public static void PriceExecute(int Price,string tbname)
        {
            SQLiteConnection connect = new SQLiteConnection(DBPath);
            try
            {
                connect.Open();
                if(connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE "+tbname+ " SET CD_Price=@CD_Price " +
                        "WHERE Infopren_Code='" + infoprencode+"'", connect);
                    cmd.Parameters.AddWithValue("@CD_Price", Price);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<object> CheckDeviceData()
        {
            List<object> datalst = new List<object>();
            try
            {
                if (serialnumber != "" && serialnumber != "S/N" && serialnumber != null)
                {
                    datalst.Add(serialnumber);
                }
                else
                {
                    datalst.Add(DBNull.Value);
                }


                if (cdname != "" && cdname != "Name-Surname" && cdname != null)
                {
                    datalst.Add(cdname);
                }
                else
                {
                    throw new Exception("Name Is Empty !!!");
                    
                }


                if (cdphone != "" && cdphone != "Phone Number" && cdphone != null)
                {
                    datalst.Add(cdphone);
                }
                else
                {
                    throw new Exception("Phone Number Is Empty !!!");

                }


                if (cdexternal != "" && cdexternal != null)
                {
                    datalst.Add(cdexternal);
                }
                else
                {
                    datalst.Add(DBNull.Value);
                }


                if (cddevicecompany != "" && cddevicecompany != "Device Company" && cddevicecompany != null)
                {
                    datalst.Add(cddevicecompany);
                }
                else
                {
                    throw new Exception("Device Company Is Empty !!!");
                }


                if (cdmodel != "" && cdmodel != "Model" && cdmodel != null)
                {
                    
                    datalst.Add(cdmodel);
                }
                else
                {
                    throw new Exception("Model Is Empty !!!");
                }


                if (cdprice != "" && cdprice != "Price" && cdprice != null)
                {
                    datalst.Add(cdprice);
                }
                else
                {
                    datalst.Add(DBNull.Value);
                }


                if(cddate == default(DateTime))
                {
                    datalst.Add(cddate = DateTime.Now);
                }else
                {
                    datalst.Add(cddate);
                }
                

                if(statusid != -1)
                {
                    if (statusid == 0)
                    {
                        datalst.Add(cdstatus.Repairing.ToString());
                    }
                    else if (statusid == 1)
                    {
                        datalst.Add(cdstatus.Completed.ToString());
                    }
                    else if (statusid == 2)
                    {
                        datalst.Add(cdstatus.Failed.ToString());
                    }
                }else
                {
                    throw new Exception("Status Is Not Selected !!!");
                }

                if(infoprencode == null)
                {
                    UniqueCode.GetChars();
                    UniqueCode.RamdomChars();
                }
                if (infoprencode != "" && infoprencode != "Code" )
                {
                    datalst.Insert(0, infoprencode);
                }
                else
                {
                    throw new Exception("Code Is Empty !!!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {

            }
            
            
            return datalst;
        }
    }
}
