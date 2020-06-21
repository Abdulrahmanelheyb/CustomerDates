using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class Computer : Device
    {
        public Computer()
        {

        }

        public static List<HardwarePart> HardwareParts = new List<HardwarePart>();
        public static List<SoftwarePart> SoftwareParts = new List<SoftwarePart>();
        public static List<string> HardwarePartsTypes = new List<string>();
        public static List<string> SoftwarePartsTypes = new List<string>();

        public static int SumComputerPartsPrice()
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
