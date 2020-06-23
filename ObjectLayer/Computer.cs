using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectLayer
{
    public class Computer : Device
    {
        public Computer()
        {
            
        }
        public static List<Computer> Computers = new List<Computer>();
        

        public static int SumComputerPartsPrice()
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
