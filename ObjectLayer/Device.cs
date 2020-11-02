using ObjectLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ObjectLayer
{
    /// <summary>
    /// This Device Class has property and method to all device.
    /// </summary>
    public class Device
      {
        
        
        public string DeviceInformationCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceCompany { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public DateTime Date { get;  set; }
        public string Hardwares { get; set; }
        public string Softwares { get; set; }
        public bool Validation { get; private set; }
        private enum StatusType { Repairing, Completed, Failed }
        public enum DeviceType { CMP ,LTP ,MOB ,TAB ,OTH }


        public int sumDevicePartsPrice()
        {
            int hardwareprice = 0;
            int softwareprice = 0;
            XmlReader reader = XmlReader.Create(new StringReader(Hardwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Hardwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                       hardwareprice += int.Parse(reader.GetAttribute("Price"));
                    }
                }
            }
            reader = XmlReader.Create(new StringReader(Softwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Softwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                        softwareprice += int.Parse(reader.GetAttribute("Price"));
                    }
                }
            }
            return hardwareprice + softwareprice;
        }
        public string setStatus()
        {
            StatusType finalstatus = default;
            List<string> statuses = new List<string>();
            int repairnum = 0;
            int completednum = 0;
            int failednum = 0;
            XmlReader reader = XmlReader.Create(new StringReader(Hardwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Hardwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                        statuses.Add(reader.GetAttribute("Status"));
                    }
                }
            }
            reader = XmlReader.Create(new StringReader(Softwares));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Softwares")
                {
                    if (reader.GetAttribute("Availability") == "True")
                    {
                        statuses.Add(reader.GetAttribute("Status"));
                    }
                }
            }

            foreach (string text in statuses)
            {
                if (text == StatusType.Repairing.ToString())
                {
                    repairnum++;
                }
                if (text == StatusType.Completed.ToString())
                {
                    completednum++;
                }
                if (text == StatusType.Failed.ToString())
                {
                    failednum++;
                }
            }

            if (repairnum >0)
            {
                finalstatus = StatusType.Repairing;
            }
            if (completednum >0 && repairnum <1)
            {
                finalstatus = StatusType.Completed;
            }
            if (failednum >0 && completednum <1 && repairnum <1)
            {
                finalstatus = StatusType.Failed;
            }

            return finalstatus.ToString();
        }
        public bool ValidateData()
        {
            bool rlt = true;
            if (string.IsNullOrEmpty(CustomerName) == false && string.IsNullOrWhiteSpace(CustomerName) == false && CustomerName.Length < 2)
            {
                throw new Exception("The Name Length Under Limit");
            }

            if (string.IsNullOrEmpty(CustomerPhoneNumber) == false && string.IsNullOrWhiteSpace(CustomerPhoneNumber) == false && CustomerPhoneNumber.Length < 11)
            {
                throw new Exception("The Phone Number Under Limit");
            }

            if (string.IsNullOrEmpty(Model) == false && string.IsNullOrWhiteSpace(Model) == false && Model.Length < 4)
            {
                throw new Exception("The Model Length Under Limit");
            }

            Validation = rlt;
            return rlt;
        }
        public bool GenerateDeviceInformationCode(DeviceType deviceType)
        {
            bool rlt = false;
            string Gchars = null;
            string last = null;
            if (Validation == true)
            {
                Gchars += CustomerName[CustomerName.Length - 1].ToString() + CustomerName[CustomerName.Length - 2].ToString();
                Gchars = Gchars + CustomerPhoneNumber[CustomerPhoneNumber.Length - 1].ToString() + CustomerPhoneNumber[CustomerPhoneNumber.Length - 2].ToString() + CustomerPhoneNumber[CustomerPhoneNumber.Length - 3].ToString() + CustomerPhoneNumber[CustomerPhoneNumber.Length - 4].ToString();
                Gchars += Model[Model.Length - 1].ToString() + Model[Model.Length - 2].ToString();

                char[] CharCodeArray = Gchars.ToCharArray();
                Random rdm = new Random();
                int Charindex;

                do
                {
                    Charindex = rdm.Next(0, 8);
                    if (CharCodeArray[Charindex] != '*')
                    {
                        last += CharCodeArray[Charindex].ToString();
                        CharCodeArray[Charindex] = '*';
                    }

                } while (last.Length != 8);

                if (last.Length == 8)
                {
                    DeviceInformationCode = last.Insert(0, deviceType.ToString()).ToUpper();
                    rlt = true;
                }
                else
                {
                    throw new Exception("Error in code generate !!!");
                }
                
            }
            return rlt;
        }
    }
}

