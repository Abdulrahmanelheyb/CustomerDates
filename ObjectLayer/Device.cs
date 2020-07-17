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
      public class Device
     {
        
        
        public string DeviceInformationCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceCompany { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get;  set; }
        public string Hardwares { get; set; }
        public string Softwares { get; set; }
        public enum StatusType { Repairing, Completed, Failed }


        public int SumDevicePartsPrice()
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
    }
}

