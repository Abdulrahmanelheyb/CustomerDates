using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class Laptop : Device
    {
        public Laptop()
        {

        }
        public static List<Laptop> Laptops = new List<Laptop>();
        public static List<string> ExternalsTypes = new List<string>();

        public string Externals { get; set; }

        public static int SumLaptopPartsPrice()
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
