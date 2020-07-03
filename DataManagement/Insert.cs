using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ObjectLayer;
using System.Data;

namespace DataManagement
{
    public class Insert
    {
        

        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad;
        private static SQLiteDataReader dare;
        
        public static bool InsertDevice(Computer Computer)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Computers " +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", con);

                    cmd.Parameters.AddWithValue("@Infopren_Code", Computer.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Computer.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Computer.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Computer.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Computer.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Computer.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Computer.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Computer.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Computer.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    insertresult = true;
                }
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


            
            
            return insertresult;
            
        }

        public static bool InsertDevice(Laptop Laptop)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Laptops " +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Externals,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Externals,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", con);

                    cmd.Parameters.AddWithValue("@Infopren_Code", Laptop.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Laptop.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Laptop.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Laptop.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Laptop.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Laptop.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Laptop.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Laptop.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Laptop.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Laptop.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    insertresult = true;
                }
            }
            catch (Exception)
            {


            }


            return insertresult;
        }

        public static bool InsertDevice(Mobile Mobile)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Mobiles " +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Externals,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Externals,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", con);

                    cmd.Parameters.AddWithValue("@Infopren_Code", Mobile.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Mobile.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Mobile.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Mobile.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Mobile.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Mobile.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Mobile.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Mobile.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Mobile.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Mobile.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    insertresult = true;
                }
            }
            catch (Exception)
            {


            }


            return insertresult;
        }

        public static bool InsertDevice(Tablet Tablet)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Tablets " +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Externals,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Externals,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", con);

                    cmd.Parameters.AddWithValue("@Infopren_Code", Tablet.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Tablet.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Tablet.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Tablet.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Tablet.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", Tablet.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", Tablet.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", Tablet.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", Tablet.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", Tablet.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    insertresult = true;
                }
            }
            catch (Exception)
            {


            }


            return insertresult;
        }
        public static bool InsertDevice(OtherDevice OtherDevice)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Otherdevices " +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Externals,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Externals,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", con);

                    cmd.Parameters.AddWithValue("@Infopren_Code", OtherDevice.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", OtherDevice.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", OtherDevice.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", OtherDevice.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", OtherDevice.Externals);
                    cmd.Parameters.AddWithValue("@CD_Device_company", OtherDevice.DeviceCompany);
                    cmd.Parameters.AddWithValue("@CD_Model", OtherDevice.Model);
                    cmd.Parameters.AddWithValue("@CD_Price", OtherDevice.Price);
                    cmd.Parameters.AddWithValue("@CD_Date", OtherDevice.Date);
                    cmd.Parameters.AddWithValue("@CD_Status", OtherDevice.Status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    insertresult = true;
                }
            }
            catch (Exception)
            {


            }


            return insertresult;
        }
    }
}
