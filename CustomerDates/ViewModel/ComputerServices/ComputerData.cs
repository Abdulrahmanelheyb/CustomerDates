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

        public static IEnumerable<Computer> SearchComputer()
        {
            return Computer.Computers;
        }

        public static IEnumerable<Computer> SearchComputer(string Type, string Value)
        {
            IEnumerable<Computer> computers = Computer.Computers;
            if (Type == "Name")
            {
               return Computer.Computers.Where(x => x.CustomerName.StartsWith(Value));
            }
            if (Type == "PhoneNumber")
            {
                return Computer.Computers.Where(x => x.CustomerPhoneNumber.StartsWith(Value));
            }
            if (Type == "DeviceCompany")
            {
                return Computer.Computers.Where(x => x.DeviceCompany.StartsWith(Value));
            }
            if (Type == "SerialNumber")
            {
                return Computer.Computers.Where(x => x.SerialNumber.StartsWith(Value));
            }
            if (Type == "Model")
            {
                return Computer.Computers.Where(x => x.Model.StartsWith(Value));
            }
            if (Type == "DeviceInformationCode")
            {
                return Computer.Computers.Where(x => x.DeviceInformationCode.StartsWith(Value));
            }
            if (Type == "Price")
            {
                return Computer.Computers.Where(x =>x.Price.ToString().StartsWith(Value));
            }
            if (Type == "Date")
            {
                return Computer.Computers.Where(x => x.Date.ToString().StartsWith(Value));
            }
            if (Type == "Status")
            {
                return Computer.Computers.Where(x => x.Status.ToString().StartsWith(Value));
            }
            return computers;
        }
        
        


    }
}
