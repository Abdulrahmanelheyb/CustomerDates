﻿using System;
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
        private static SQLiteDataReader dare = null;


        public static bool SearchDevice(string PropertyType , string Value)
        {
            bool searchresult = false;
            Computer.Computers.Clear();
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    // cmd = new SQLiteCommand(
                    //"SELECT * FROM Computers WHERE " +
                    //PropertyType+" LIKE '@"+ PropertyType + "'" , con);
                    //cmd.Parameters.AddWithValue("@"+PropertyType, Value);

                    cmd = new SQLiteCommand("SELECT * FROM Computers WHERE CD_Name LIKE 'name1'", con);
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
                        computer.CustomerPhoneNumber = dare.GetInt64(3).ToString();
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
                        Computer.Computers.Add(computer);
                    }

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
            if (Laptop is null)
            {
                throw new ArgumentNullException(nameof(Laptop));
            }

            bool searchresult = false;

            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                     cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "DeviceInformationCode LIKE '@DeviceInformationCode' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Laptop.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Laptop.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Laptop.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Laptop.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Laptop.Extras);
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
            if (Mobile is null)
            {
                throw new ArgumentNullException(nameof(Mobile));
            }

            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "DeviceInformationCode LIKE '@DeviceInformationCode' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Mobile.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Mobile.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Mobile.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Mobile.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Mobile.Extras);
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
            if (Tablet is null)
            {
                throw new ArgumentNullException(nameof(Tablet));
            }

            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "DeviceInformationCode LIKE '@DeviceInformationCode' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@DeviceInformationCode", Tablet.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", Tablet.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", Tablet.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", Tablet.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", Tablet.Extras);
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
            if (OtherDevice is null)
            {
                throw new ArgumentNullException(nameof(OtherDevice));
            }

            bool searchresult = false;
            
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand(
                    "SELECT * FROM Computers WHERE " +
                    "DeviceInformationCode LIKE '@DeviceInformationCode' " +
                    "OR Serial_Number LIKE '@Serial_Number' " +
                    "OR CD_Name LIKE '@CD_Name' " +
                    "OR CD_Phone LIKE '@CD_Phone' " +
                    "OR CD_Externals LIKE '@CD_Externals'" +
                    "OR CD_Device_company LIKE '@CD_Device_company' " +
                    "OR CD_Model LIKE '@CD_Model' " +
                    "OR CD_Price LIKE '@CD_Price' " +
                    "OR CD_Date LIKE '@CD_Date' " +
                    "OR CD_Status LIKE '@CD_Status'", con);
                    cmd.Parameters.AddWithValue("@DeviceInformationCode", OtherDevice.DeviceInformationCode);
                    cmd.Parameters.AddWithValue("@Serial_Number", OtherDevice.SerialNumber);
                    cmd.Parameters.AddWithValue("@CD_Name", OtherDevice.CustomerName);
                    cmd.Parameters.AddWithValue("@CD_Phone", OtherDevice.CustomerPhoneNumber);
                    cmd.Parameters.AddWithValue("@CD_Externals", OtherDevice.Extras);
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
