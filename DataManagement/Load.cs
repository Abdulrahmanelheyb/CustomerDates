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
    public class Load
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad;
        private static SQLiteDataReader dare;
        public static bool LoadComputers()
        {
            bool loadresult = false;
            Computer computer;
            Computer.Computers.Clear();
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Computers", con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        computer = new Computer();
                        computer.InformationProvioslyEnteredCode = dare.GetString(0);
                        computer.SerialNumber = dare.GetString(1);
                        computer.CustomerName = dare.GetString(2);
                        computer.CustomerPhoneNumber = dare.GetString(3);
                        computer.DeviceCompany = dare.GetString(4);
                        computer.Model = dare.GetString(5);
                        computer.Price = dare.GetInt32(6);
                        computer.Date = dare.GetDateTime(7);
                        computer.Status = dare.GetString(8);
                        Computer.Computers.Add(computer);
                    }
                    con.Close();
                    loadresult = true;
                }
                
            }
            catch(Exception)
            {
                
            }
            return loadresult;
        }
        public static bool LoadLaptops()
        {
            bool loadresult = false;
            Laptop.Laptops.Clear();
            Laptop laptop;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Laptops", con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        laptop = new Laptop();
                        laptop.InformationProvioslyEnteredCode = dare.GetString(0);
                        laptop.SerialNumber = dare.GetString(1);
                        laptop.CustomerName = dare.GetString(2);
                        laptop.CustomerPhoneNumber = dare.GetString(3);
                        laptop.Externals = dare.GetString(4);
                        laptop.DeviceCompany = dare.GetString(5);
                        laptop.Model = dare.GetString(6);
                        laptop.Price = dare.GetInt32(7);
                        laptop.Date = dare.GetDateTime(8);
                        laptop.Status = dare.GetString(9);
                        Laptop.Laptops.Add(laptop);
                    }
                    con.Close();
                    loadresult = true;
                }
            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadMobiles()
        {
            bool loadresult = false;
            Mobile.Mobiles.Clear();
            Mobile mobile;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Mobiles", con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        mobile = new Mobile();
                        mobile.InformationProvioslyEnteredCode = dare.GetString(0);
                        mobile.SerialNumber = dare.GetString(1);
                        mobile.CustomerName = dare.GetString(2);
                        mobile.CustomerPhoneNumber = dare.GetString(3);
                        mobile.Externals = dare.GetString(4);
                        mobile.DeviceCompany = dare.GetString(5);
                        mobile.Model = dare.GetString(6);
                        mobile.Price = dare.GetInt32(7);
                        mobile.Date = dare.GetDateTime(8);
                        mobile.Status = dare.GetString(9);
                        Mobile.Mobiles.Add(mobile);
                    }
                    con.Close();
                    loadresult = true;
                }
            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadTablets()
        {
            bool loadresult = false;
            Tablet.Tablets.Clear();
            Tablet tablet;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Tablets", con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        tablet = new Tablet();
                        tablet.InformationProvioslyEnteredCode = dare.GetString(0);
                        tablet.SerialNumber = dare.GetString(1);
                        tablet.CustomerName = dare.GetString(2);
                        tablet.CustomerPhoneNumber = dare.GetString(3);
                        tablet.Externals = dare.GetString(4);
                        tablet.DeviceCompany = dare.GetString(5);
                        tablet.Model = dare.GetString(6);
                        tablet.Price = dare.GetInt32(7);
                        tablet.Date = dare.GetDateTime(8);
                        tablet.Status = dare.GetString(9);
                        Tablet.Tablets.Add(tablet);
                    }
                    con.Close();
                    loadresult = true;
                }
            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadOtherDevices()
        {
            bool loadresult = false;
            OtherDevice.OtherDevices.Clear();
            OtherDevice otherdevice;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Otherdevices", con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        otherdevice = new OtherDevice();
                        otherdevice.InformationProvioslyEnteredCode = dare.GetString(0);
                        otherdevice.SerialNumber = dare.GetString(1);
                        otherdevice.CustomerName = dare.GetString(2);
                        otherdevice.CustomerPhoneNumber = dare.GetString(3);
                        otherdevice.Externals = dare.GetString(4);
                        otherdevice.DeviceCompany = dare.GetString(5);
                        otherdevice.Model = dare.GetString(6);
                        otherdevice.Price = dare.GetInt32(7);
                        otherdevice.Date = dare.GetDateTime(8);
                        otherdevice.Status = dare.GetString(9);
                        OtherDevice.OtherDevices.Add(otherdevice);
                    }
                    con.Close();
                    loadresult = true;
                }
            }
            catch (Exception)
            {

            }
            return loadresult;
        }
    }
}
