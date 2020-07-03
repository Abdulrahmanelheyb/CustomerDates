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
    public class Update
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        public static bool UpdateDevice(Computer Computer)
        {
            bool updateresult = false;
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("UPDATE Computers SET Infopren_Code = @Infopren_Code," +
                        "Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Device_company=@CD_Device_company,CD_Model=@CD_Model," +
                        "CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" +Computer.DeviceInformationCode + "'", con);

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
                    updateresult = true;
                    con.Close();
                }
            }
            catch (Exception)
            {

                
            }

            return updateresult;
        }

        public static bool UpdateDevice(Laptop Laptop)
        {
            bool updateresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("UPDATE Laptops SET Infopren_Code = @Infopren_Code," +
                        "Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Externals=@CD_Externals,CD_Device_company=@CD_Device_company,CD_Model=@CD_Model," +
                        "CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" + Laptop.DeviceInformationCode + "'", con);

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
                    updateresult = true;
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

            return updateresult;
        }

        public static bool UpdateDevice(Mobile Mobile)
        {
            bool updateresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("UPDATE Mobiles SET Infopren_Code = @Infopren_Code," +
                        "Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Externals=@CD_Externals,CD_Device_company=@CD_Device_company,CD_Model=@CD_Model," +
                        "CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" + Mobile.DeviceInformationCode + "'", con);

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
                    updateresult = true;
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

            return updateresult;
        }

        public static bool UpdateDevice(Tablet Tablet)
        {
            bool updateresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("UPDATE Tablets SET Infopren_Code = @Infopren_Code," +
                        "Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Externals=@CD_Externals,CD_Device_company=@CD_Device_company,CD_Model=@CD_Model," +
                        "CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" + Tablet.DeviceInformationCode + "'", con);

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
                    updateresult = true;
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

            return updateresult;
        }
        public static bool UpdateDevice(OtherDevice OtherDevice)
        {
            bool updateresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("UPDATE Otherdevices SET Infopren_Code = @Infopren_Code," +
                        "Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Externals=@CD_Externals,CD_Device_company=@CD_Device_company,CD_Model=@CD_Model," +
                        "CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" + OtherDevice.DeviceInformationCode + "'", con);

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
                    updateresult = true;
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

            return updateresult;
        }
    }
}
