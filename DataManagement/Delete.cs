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
    public class Delete
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        

        public static bool Delete_Device(Computer Computer)
        {
            bool rlt = false;
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Computers WHERE DeviceInformationCode='" + 
                        Computer.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    rlt = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rlt;
        }
        public static void Delete_Device(Laptop Laptop)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Laptops WHERE DeviceInformationCode='" +
                        Laptop.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete_Device(Mobile Mobile)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Mobiles WHERE DeviceInformationCode='" +
                        Mobile.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete_Device(Tablet Tablet)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Tablets WHERE DeviceInformationCode='" +
                        Tablet.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete_Device(OtherDevice OtherDevice)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Otherdevices WHERE DeviceInformationCode='" +
                        OtherDevice.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
