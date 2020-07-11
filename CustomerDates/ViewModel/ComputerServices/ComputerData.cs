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
        #region Chacking Data
        private static bool CheckComputer(Computer computer)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(computer.DeviceInformationCode) &&
                    string.IsNullOrWhiteSpace(computer.DeviceInformationCode))
                {

                }

                if (string.IsNullOrEmpty(computer.SerialNumber) == true && string.IsNullOrWhiteSpace(computer.SerialNumber) == true)
                {
                    computer.SerialNumber = DBNull.Value.ToString();
                }

                if (string.IsNullOrEmpty(computer.CustomerName) && string.IsNullOrWhiteSpace(computer.CustomerName))
                {
                    throw new Exception("Please enter customer name");
                }

                if (string.IsNullOrEmpty(computer.CustomerPhoneNumber) && string.IsNullOrWhiteSpace(computer.CustomerPhoneNumber))
                {
                    throw new Exception("Please enter customer phone number");
                }

                if (string.IsNullOrEmpty(computer.DeviceCompany) && string.IsNullOrWhiteSpace(computer.DeviceCompany))
                {
                    throw new Exception("Please enter customer device company");
                }

                if (string.IsNullOrEmpty(computer.Model) && string.IsNullOrWhiteSpace(computer.Model))
                {
                    throw new Exception("Please enter model");
                }

                if (computer.Price <= -1)
                {
                    //throw new Exception("Please enter price");
                    // the check is need get only int for get correct values
                }

                if (computer.Date == default)
                {
                    throw new Exception("ERROR | Date is empty");
                }

                if (string.IsNullOrEmpty(computer.Status.ToString()) && string.IsNullOrWhiteSpace(computer.Status.ToString()))
                {
                    throw new Exception("Please enter status");
                }

                result = true;
            }
            catch (Exception exc)
            {
                throw new ApplicationException("ERROR | Data fields \n", exc);
            }
            return result;
        }
        public static void CheckHardware(Hardware hardware)
        {
            try
            {
                if (string.IsNullOrEmpty(hardware.DeviceInformationCode) &&
                    string.IsNullOrWhiteSpace(hardware.DeviceInformationCode))
                {
                    throw new Exception("ERROR | Code is not correct !");
                }

                if (string.IsNullOrEmpty(hardware.Parttype) && string.IsNullOrWhiteSpace(hardware.Parttype))
                {
                    throw new Exception("ERROR | Parttype is not correct !");
                }

                if (string.IsNullOrEmpty(hardware.Description) && string.IsNullOrWhiteSpace(hardware.Description))
                {
                    hardware.Description = DBNull.Value.ToString();
                }

                if (hardware.Price <= -1)
                {
                    throw new Exception("ERROR | Price is not correct !");
                }

                if (string.IsNullOrEmpty(hardware.Status) && string.IsNullOrWhiteSpace(hardware.Status))
                {
                    throw new Exception("ERROR | Status is not correct !");
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("ERROR | Data fields in hardware \n");
            }

        }
        public static void CheckSoftware(Software software)
        {
            try
            {
                if (string.IsNullOrEmpty(software.DeviceInformationCode) &&
                    string.IsNullOrWhiteSpace(software.DeviceInformationCode))
                {
                    throw new Exception("ERROR | Code is not correct !");
                }

                if (string.IsNullOrEmpty(software.Parttype) && string.IsNullOrWhiteSpace(software.Parttype))
                {
                    throw new Exception("ERROR | Parttype is not correct !");
                }

                if (string.IsNullOrEmpty(software.Description) && string.IsNullOrWhiteSpace(software.Description))
                {
                    software.Description = DBNull.Value.ToString();
                }

                if (software.Price <= -1)
                {
                    throw new Exception("ERROR | Price is not correct !");
                }

                if (string.IsNullOrEmpty(software.Status) && string.IsNullOrWhiteSpace(software.Status))
                {
                    throw new Exception("ERROR | Status is not correct !");
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("ERROR | Data fields in software \n");
            }
        }
        #endregion


        public static bool InsertComputer(Computer computer)
        {
            bool result = false;
            try
            {
                if (CheckComputer(computer) == true)
                {
                    UniqueCode.GetCode(computer);
                    result = Insert.InsertDevice(computer);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }

        public static bool UpdateComputer(Computer computer)
        {
            bool result = false;
            try
            {
                if (CheckComputer(computer) == true)
                {
                    result = Update.UpdateDevice(computer);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static bool DeleteComputer(Computer computer)
        {
            return Delete.Delete_Device(computer);
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
