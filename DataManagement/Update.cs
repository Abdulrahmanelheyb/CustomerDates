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
                    cmd = new SQLiteCommand("UPDATE Computers SET DeviceInformationCode = @DeviceInformationCode," +
                        "SerialNumber=@SerialNumber,CustomerName=@CustomerName,PhoneNumber=@PhoneNumber," +
                        "DeviceCompany=@DeviceCompany,DeviceModel=@DeviceModel," +
                        "TotalPrice=@TotalPrice,RegisterDate=@RegisterDate," +
                        "DeviceStatus=@DeviceStatus,Hardwares=@Hardwares,Softwares=@Softwares " +
                        "WHERE DeviceInformationCode='" +Computer.DeviceInformationCode + "'", con);

                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Computer.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@SerialNumber", Computer.SerialNumber);
                    cmd.Parameters.AddWithValue("@CustomerName", Computer.CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", Computer.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@DeviceCompany", Computer.DeviceCompany);
                    cmd.Parameters.AddWithValue("@DeviceModel", Computer.Model);
                    cmd.Parameters.AddWithValue("@TotalPrice", Computer.Price);
                    cmd.Parameters.AddWithValue("@RegisterDate", Computer.Date);
                    cmd.Parameters.AddWithValue("@DeviceStatus", Computer.Status);
                    cmd.Parameters.AddWithValue("@Hardwares",Computer.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares", Computer.Softwares);
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
                    cmd = new SQLiteCommand("UPDATE Laptops SET DeviceInformationCode = @DeviceInformationCode," +
                        "SerialNumber=@SerialNumber,CustomerName=@CustomerName,PhoneNumber=@PhoneNumber," +
                        "Extras=@Extras,DeviceCompany=@DeviceCompany,DeviceModel=@DeviceModel," +
                        "TotalPrice=@TotalPrice,RegisterDate=@RegisterDate," +
                        "DeviceStatus=@DeviceStatus,Hardwares=@Hardwares,Softwares=@Softwares " +
                        "WHERE DeviceInformationCode='" + Laptop.DeviceInformationCode + "'", con);

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
                    cmd.Parameters.AddWithValue("@Hardwares",Laptop.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares",Laptop.Softwares);
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
                    cmd = new SQLiteCommand("UPDATE Mobiles SET DeviceInformationCode = @DeviceInformationCode," +
                        "SerialNumber=@SerialNumber,CustomerName=@CustomerName,PhoneNumber=@PhoneNumber," +
                        "Extras=@Extras,DeviceCompany=@DeviceCompany,DeviceModel=@DeviceModel," +
                        "TotalPrice=@TotalPrice,RegisterDate=@RegisterDate," +
                        "DeviceStatus=@DeviceStatus,Hardwares=@Hardwares,Softwares=@Softwares " +
                        "WHERE DeviceInformationCode='" + Mobile.DeviceInformationCode + "'", con);

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
                    cmd.Parameters.AddWithValue("@Hardwares",Mobile.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares",Mobile.Softwares);
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
                    cmd = new SQLiteCommand("UPDATE Tablets SET DeviceInformationCode = @DeviceInformationCode," +
                        "SerialNumber=@SerialNumber,CustomerName=@CustomerName,PhoneNumber=@PhoneNumber," +
                        "Extras=@Extras,DeviceCompany=@DeviceCompany,DeviceModel=@DeviceModel," +
                        "TotalPrice=@TotalPrice,RegisterDate=@RegisterDate," +
                        "DeviceStatus=@DeviceStatus,Hardwares=@Hardwares,Softwares=@Softwares " +
                        "WHERE DeviceInformationCode='" + Tablet.DeviceInformationCode + "'", con);

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
                    cmd.Parameters.AddWithValue("@Hardwares",Tablet.Hardwares);
                    cmd.Parameters.AddWithValue("@Softwares",Tablet.Softwares);
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
                    cmd = new SQLiteCommand("UPDATE Otherdevices SET DeviceInformationCode = @DeviceInformationCode," +
                        "SerialNumber=@SerialNumber,CustomerName=@CustomerName,PhoneNumber=@PhoneNumber," +
                        "Extras=@Extras,DeviceCompany=@DeviceCompany,DeviceModel=@DeviceModel," +
                        "TotalPrice=@TotalPrice,RegisterDate=@RegisterDate," +
                        "DeviceStatus=@DeviceStatus,Hardwares=@Hardwares,Softwares=@Softwares " +
                        "WHERE DeviceInformationCode='" + OtherDevice.DeviceInformationCode + "'", con);

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
