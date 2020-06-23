using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class Mobile : Device
    {
        public Mobile()
        {

        }
        public static List<Mobile> Mobiles = new List<Mobile>();
        public static List<string> ExternalsTypes = new List<string>();

        public string Externals { get; set; }

        public static int SumMobilePartsPrice()
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
