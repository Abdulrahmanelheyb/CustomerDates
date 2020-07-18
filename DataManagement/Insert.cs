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
        public enum HardwarePartType { Computer_Hardwares , Laptop_Hardwares , Mobile_Hardwares , Tablet_Hardwares , OtherDevice_Hardwares }
        public enum SoftwarePartType { Computer_Softwares, Laptop_Softwares, Mobile_Softwares, Tablet_Softwares, OtherDevice_Softwares }
        
        public static bool InsertDevice(Computer Computer)
        {
            bool insertresult = false;
            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("INSERT INTO Computers " +
                        " (DeviceInformationCode,SerialNumber,CustomerName,PhoneNumber,DeviceCompany,DeviceModel," +
                        "TotalPrice,RegisterDate,DeviceStatus,Hardwares,Softwares)" +
                        " VALUES (@DeviceInformationCode,@SerialNumber,@CustomerName,@PhoneNumber,@DeviceCompany," +
                        "@DeviceModel,@TotalPrice,@RegisterDate,@DeviceStatus,@Hardwares,@Softwares)", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Computer.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", Computer.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", Computer.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Computer.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@DeviceCompany", Computer.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", Computer.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", Computer.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", Computer.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", Computer.Status);
                    cmd.Parameters.AddWithValue("@Hardwares", Computer.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", Computer.Softwares);
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
                        " (DeviceInformationCode,SerialNumber,CustomerName,PhoneNumber,Extras,DeviceCompany,DeviceModel," +
                        "TotalPrice,RegisterDate,DeviceStatus,Hardwares,Softwares)" +
                        " VALUES (@DeviceInformationCode,@SerialNumber,@CustomerName,@PhoneNumber,@Extras,@DeviceCompany," +
                        "@DeviceModel,@TotalPrice,@RegisterDate,@DeviceStatus,@Hardwares,@Softwares)", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Laptop.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", Laptop.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", Laptop.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Laptop.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@Extras", Laptop.Extras);
                    cmd.Parameters.AddWithValue("@DeviceCompany", Laptop.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", Laptop.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", Laptop.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", Laptop.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", Laptop.Status);
                    cmd.Parameters.AddWithValue("@Hardwares", Laptop.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", Laptop.Softwares);
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
                        " (DeviceInformationCode,SerialNumber,CustomerName,PhoneNumber,Extras,DeviceCompany,DeviceModel," +
                        "TotalPrice,RegisterDate,DeviceStatus,Hardwares,Softwares)" +
                        " VALUES (@DeviceInformationCode,@SerialNumber,@CustomerName,@PhoneNumber,@Extras,@DeviceCompany," +
                        "@DeviceModel,@TotalPrice,@RegisterDate,@DeviceStatus,@Hardwares,@Softwares)", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Mobile.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", Mobile.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", Mobile.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Mobile.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@Extras", Mobile.Extras);
                    cmd.Parameters.AddWithValue("@DeviceCompany", Mobile.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", Mobile.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", Mobile.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", Mobile.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", Mobile.Status);
                    cmd.Parameters.AddWithValue("@Hardwares", Mobile.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", Mobile.Softwares);
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
                        " (DeviceInformationCode,SerialNumber,CustomerName,PhoneNumber,Extras,DeviceCompany,DeviceModel," +
                        "TotalPrice,RegisterDate,DeviceStatus,Hardwares,Softwares)" +
                        " VALUES (@DeviceInformationCode,@SerialNumber,@CustomerName,@PhoneNumber,@Extras,@DeviceCompany," +
                        "@DeviceModel,@TotalPrice,@RegisterDate,@DeviceStatus,@Hardwares,@Softwares)", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Tablet.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", Tablet.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", Tablet.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Tablet.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@Extras", Tablet.Extras);
                    cmd.Parameters.AddWithValue("@DeviceCompany", Tablet.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", Tablet.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", Tablet.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", Tablet.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", Tablet.Status);
                    cmd.Parameters.AddWithValue("@Hardwares", Tablet.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", Tablet.Softwares);
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
                        " (DeviceInformationCode,SerialNumber,CustomerName,PhoneNumber,Extras,DeviceCompany,DeviceModel," +
                        "TotalPrice,RegisterDate,DeviceStatus,Hardwares,Softwares)" +
                        " VALUES (@DeviceInformationCode,@SerialNumber,@CustomerName,@PhoneNumber,@Extras,@DeviceCompany," +
                        "@DeviceModel,@TotalPrice,@RegisterDate,@DeviceStatus,@Hardwares,@Softwares)", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", OtherDevice.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", OtherDevice.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", OtherDevice.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", OtherDevice.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@Extras", OtherDevice.Extras);
                    cmd.Parameters.AddWithValue("@DeviceCompany", OtherDevice.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", OtherDevice.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", OtherDevice.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", OtherDevice.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", OtherDevice.Status);
                    cmd.Parameters.AddWithValue("@Hardwares", OtherDevice.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", OtherDevice.Softwares);
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
