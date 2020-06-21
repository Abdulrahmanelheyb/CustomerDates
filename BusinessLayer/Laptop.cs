using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Laptop : Device
    {
        public Laptop()
        {

        }

        public static List<HardwarePart> HardwareParts = new List<HardwarePart>();
        public static List<SoftwarePart> SoftwareParts = new List<SoftwarePart>();
        public static List<string> HardwarePartsTypes = new List<string>();
        public static List<string> SoftwarePartsTypes = new List<string>();
        public static List<string> ExtraParts = new List<string>();

        public static int SumLaptopPartsPrice()
        {
            int result = 0;
            foreach (HardwarePart Hpart in HardwareParts)
            {
                result += Hpart.Price;
            }
            foreach (SoftwarePart Spart in SoftwareParts)
            {
                result += Spart.Price;
            }

            return result;
        }
    }
}
