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
    class Delete
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        

        public static void Delete_Device(Computer Computer)
        {
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Computers WHERE Infopren_Code='" + 
                        Computer.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

                
            }
        }
        public static void Delete_Device(Laptop Laptop)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Laptops WHERE Infopren_Code='" +
                        Laptop.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception)
            {


            }
        }
        public static void Delete_Device(Mobile Mobile)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Mobiles WHERE Infopren_Code='" +
                        Mobile.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception)
            {


            }
        }
        public static void Delete_Device(Tablet Tablet)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Tablets WHERE Infopren_Code='" +
                        Tablet.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception)
            {


            }
        }
        public static void Delete_Device(OtherDevice OtherDevice)
        {
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("DELETE FROM Otherdevices WHERE Infopren_Code='" +
                        OtherDevice.DeviceInformationCode + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
