using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class Tablet : Device
    {   
        public Tablet()
        {

        }
        public static List<Tablet> Tablets = new List<Tablet>();
        public static List<string> ExternalsTypes = new List<string>();

        public string Externals { get; set; }

        public static int SumTabletPartsPrice()
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
