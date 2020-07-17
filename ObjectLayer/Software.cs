using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class Software
    {
        public static List<Software> Softwares = new List<Software>();
        public int ID { get; set; }
        public string DeviceInformationCode { get; set; }
        public string Parttype { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
    }
}
