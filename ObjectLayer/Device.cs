using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
      public class Device
     {
        public static List<Hardware> Hardwares = new List<Hardware>();
        public static List<Software> Softwares = new List<Software>();
        public static List<string> HardwaresTypes = new List<string>();
        public static List<string> SoftwaresTypes = new List<string>();
        public string DeviceInformationCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceCompany { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public StatusType Status { get; set; }
        public DateTime Date { get;  set; }
        public enum StatusType { Repairing, Completed, Failed }

        public int SumDevicePartsPrice()
        {
            int result = 0;
            foreach (Hardware Hpart in Hardwares)
            {
                result += Hpart.Price;
            }
            foreach (Software Spart in Softwares)
            {
                result += Spart.Price;
            }

            return result;
        }
    }
}

