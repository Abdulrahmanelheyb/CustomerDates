﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ObjectLayer;
using DataManagement;
using System.Diagnostics.CodeAnalysis;
using System.Data;

namespace CustomerDates.ViewModel.ComputerServices
{
    public class ComputerData
    {
        public ComputerData()
        {
            
        }

        public static bool InsertComputer(Computer computer)
        {
            bool result = false;
            try
            {
                UniqueCode.GetCode(computer);
                result = Insert.InsertDevice(computer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return result;
        }

        public static bool UpdateComputer(Computer computer)
        {
            bool result = false;
            try
            {
                result = Update.UpdateDevice(computer);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static void DeleteComputer(Computer computer)
        {
             Delete.Delete_Device(computer);
             LoadComputer();
        }

        public static bool LoadComputer()
        {
            return Load.LoadComputers();

        }

        public static DataView SearchComputer(string Type, string Value)
        {
            DataView dv = Computer.Computers.DefaultView;
            if (Type == "Name")
            {
                dv.RowFilter = "CustomerName LIKE '%" + Value + "%'";
            }
            if (Type == "PhoneNumber")
            {
                dv.RowFilter = "PhoneNumber LIKE '%" + Value + "%'";
            }
            if (Type == "DeviceCompany")
            {
                dv.RowFilter = "DeviceCompany LIKE '%" + Value + "%'";
            }
            if (Type == "SerialNumber")
            {
                dv.RowFilter = "SerialNumber LIKE '%" + Value + "%'";
            }
            if (Type == "Model")
            {
                dv.RowFilter = "DeviceModel LIKE '%" + Value + "%'";
            }
            if (Type == "DeviceInformationCode")
            {
                dv.RowFilter = "DeviceInformationCode LIKE '%" + Value + "%'";
            }
            return dv;
        }
        
        


    }
}
