using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
      public class Device
     {
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceCompany { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime Date { get{ return Date; } private set { Convert.ToDateTime(DateTime.Now); } }
        public enum Status { Repairing, Completed, Failed }
       

     }
}

