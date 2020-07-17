using System;
using System.Collections.Generic;
using System.Data;
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
        public static DataTable Laptops = new DataTable();
        public DataTable LaptopsProperty
        {
            get
            {
                return Laptops;
            }
            set
            {
                LaptopsProperty = Laptops;
            }
        }
        public static List<string> ExternalsTypes = new List<string>();

        public string Externals { get; set; }

    }
}
