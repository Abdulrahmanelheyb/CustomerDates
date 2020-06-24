using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLayer;
using System.Data.SQLite;
using System.Data;

namespace DataManagement
{
    public class Search
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad;
        private static SQLiteDataReader dare;
        

        
        public static bool SearchDevice(Computer Computer)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "Infopren_Code LIKE '@Infopren_Code' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@Infopren_Code",Computer.InformationProvioslyEnteredCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Computer.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Computer.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Computer.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Computer.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Computer.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Computer.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Computer.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Computer.Status);


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }

        public static bool SearchDevice(Laptop Laptop)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "Infopren_Code LIKE '@Infopren_Code' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@Infopren_Code", Laptop.InformationProvioslyEnteredCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Laptop.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Laptop.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Laptop.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Laptop.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Laptop.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Laptop.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Laptop.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Laptop.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Laptop.Status);

                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {
    
            }

            return searchresult;
        }

        public static bool SearchDevice(Mobile Mobile)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "Infopren_Code LIKE '@Infopren_Code' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@Infopren_Code", Mobile.InformationProvioslyEnteredCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Mobile.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Mobile.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Mobile.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Mobile.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Mobile.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Mobile.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Mobile.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Mobile.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Mobile.Status);

                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }

        public static bool SearchDevice(Tablet Tablet)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "Infopren_Code LIKE '@Infopren_Code' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@Infopren_Code", Tablet.InformationProvioslyEnteredCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Tablet.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Tablet.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Tablet.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Tablet.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Tablet.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Tablet.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Tablet.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Tablet.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Tablet.Status);

                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }
        public static bool SearchDevice(OtherDevice OtherDevice)
        {
            bool searchresult = false;
            
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "Infopren_Code LIKE '@Infopren_Code' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@Infopren_Code", OtherDevice.InformationProvioslyEnteredCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", OtherDevice.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", OtherDevice.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", OtherDevice.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", OtherDevice.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", OtherDevice.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", OtherDevice.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", OtherDevice.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", OtherDevice.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", OtherDevice.Status);

                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }


    }
}
