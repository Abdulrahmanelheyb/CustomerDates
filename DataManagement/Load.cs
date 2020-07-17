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
        private static SQLiteDataReader dare = null;
        public static bool LoadComputers()
        {
            bool loadresult = false;
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

                        Computer computer = new Computer();
                        computer.DeviceInformationCode = dare.GetString(0);
                        if (dare.IsDBNull(1) == false)
                        {
                            computer.SerialNumber = dare.GetString(1).ToString();
                        }
                        computer.CustomerName = dare.GetString(2);
                        computer.CustomerPhoneNumber = dare.GetString(3);
                        computer.DeviceCompany = dare.GetString(4);
                        computer.Model = dare.GetString(5);
                        computer.Price = dare.GetInt32(6);
                        computer.Date = dare.GetDateTime(7);
                        if (dare.GetString(8) == Device.StatusType.Repairing.ToString())
                        {
                            computer.Status = Device.StatusType.Repairing;
                        }
                        else if (dare.GetString(8) == Device.StatusType.Completed.ToString())
                        {
                            computer.Status = Device.StatusType.Completed;
                        }
                        else if (dare.GetString(8) == Device.StatusType.Failed.ToString())
                        {
                            computer.Status = Device.StatusType.Failed;
                        }
                        if (dare.IsDBNull(9) == false)
                        {
                            computer.Hardwares = dare.GetString(9);

                        }
                        if (dare.IsDBNull(10) == false)
                        {
                            computer.Softwares = dare.GetString(10);
                        }

                        Computer.Computers.Add(computer);

                    }

                    con.Close();
                    loadresult = true;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
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
                        laptop.DeviceInformationCode = dare.GetString(0);
                        laptop.SerialNumber = dare.GetString(1);
                        laptop.CustomerName = dare.GetString(2);
                        laptop.CustomerPhoneNumber = dare.GetString(3);
                        laptop.Externals = dare.GetString(4);
                        laptop.DeviceCompany = dare.GetString(5);
                        laptop.Model = dare.GetString(6);
                        laptop.Price = dare.GetInt32(7);
                        laptop.Date = dare.GetDateTime(8);
                        if (dare.GetString(9) == Device.StatusType.Repairing.ToString())
                        {
                            laptop.Status = Device.StatusType.Repairing;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Completed.ToString())
                        {
                            laptop.Status = Device.StatusType.Completed;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Failed.ToString())
                        {
                            laptop.Status = Device.StatusType.Failed;
                        }
                        laptop.Hardwares = dare.GetString(9);
                        laptop.Softwares = dare.GetString(10);

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
                        mobile.DeviceInformationCode = dare.GetString(0);
                        mobile.SerialNumber = dare.GetString(1);
                        mobile.CustomerName = dare.GetString(2);
                        mobile.CustomerPhoneNumber = dare.GetString(3);
                        mobile.Externals = dare.GetString(4);
                        mobile.DeviceCompany = dare.GetString(5);
                        mobile.Model = dare.GetString(6);
                        mobile.Price = dare.GetInt32(7);
                        mobile.Date = dare.GetDateTime(8);
                        if (dare.GetString(9) == Device.StatusType.Repairing.ToString())
                        {
                            mobile.Status = Device.StatusType.Repairing;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Completed.ToString())
                        {
                            mobile.Status = Device.StatusType.Completed;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Failed.ToString())
                        {
                            mobile.Status = Device.StatusType.Failed;
                        }
                        mobile.Hardwares = dare.GetString(9);
                        mobile.Softwares = dare.GetString(10);

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
                        tablet.DeviceInformationCode = dare.GetString(0);
                        tablet.SerialNumber = dare.GetString(1);
                        tablet.CustomerName = dare.GetString(2);
                        tablet.CustomerPhoneNumber = dare.GetString(3);
                        tablet.Externals = dare.GetString(4);
                        tablet.DeviceCompany = dare.GetString(5);
                        tablet.Model = dare.GetString(6);
                        tablet.Price = dare.GetInt32(7);
                        tablet.Date = dare.GetDateTime(8);
                        if (dare.GetString(9) == Device.StatusType.Repairing.ToString())
                        {
                            tablet.Status = Device.StatusType.Repairing;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Completed.ToString())
                        {
                            tablet.Status = Device.StatusType.Completed;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Failed.ToString())
                        {
                            tablet.Status = Device.StatusType.Failed;
                        }
                        tablet.Hardwares = dare.GetString(9);
                        tablet.Softwares = dare.GetString(10);

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
                        otherdevice.DeviceInformationCode = dare.GetString(0);
                        otherdevice.SerialNumber = dare.GetString(1);
                        otherdevice.CustomerName = dare.GetString(2);
                        otherdevice.CustomerPhoneNumber = dare.GetString(3);
                        otherdevice.Externals = dare.GetString(4);
                        otherdevice.DeviceCompany = dare.GetString(5);
                        otherdevice.Model = dare.GetString(6);
                        otherdevice.Price = dare.GetInt32(7);
                        otherdevice.Date = dare.GetDateTime(8);
                        if (dare.GetString(9) == Device.StatusType.Repairing.ToString())
                        {
                            otherdevice.Status = Device.StatusType.Repairing;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Completed.ToString())
                        {
                            otherdevice.Status = Device.StatusType.Completed;
                        }
                        else if (dare.GetString(9) == Device.StatusType.Failed.ToString())
                        {
                            otherdevice.Status = Device.StatusType.Failed;
                        }
                        otherdevice.Hardwares = dare.GetString(9);
                        otherdevice.Softwares = dare.GetString(10);

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
