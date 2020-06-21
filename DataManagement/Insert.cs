using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataManagement
{
    public class Insert
    {
        public static bool InsertDevice(Laptop Laptop)
        {
            bool insertresult = false;
            Laptop.CustomerName = "12";
            
            return insertresult;
        }

        public static bool InsertDevice(Computer Laptop)
        {
            bool insertresult = false;
            Laptop.CustomerName = "12";

            return insertresult;
        }
    }
}
