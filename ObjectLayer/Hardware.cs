using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectLayer
{
    public class Hardware
    {
        public static List<Hardware> Hardwares = new List<Hardware>()
        {
            new Hardware() {Parttype = "Socket"}
        };
        public int ID { get; set; }
        public string DeviceInformationCode { get; set; }
        public string Parttype { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
    }
}
