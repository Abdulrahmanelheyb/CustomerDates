using System;
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
        public static bool InsertComputer(Computer computer)
        {
            bool result;
            try
            {
                computer.ValidateData();
                computer.GenerateDeviceInformationCode(Device.DeviceType.CMP);
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
            bool result;
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
            DataView dv = new DataView();
            dv = Computer.ComputersProperty.DefaultView;
            dv.RowFilter = Type + " LIKE '%" + Value + "%'";
            return dv;
        }
        
        


    }
}
