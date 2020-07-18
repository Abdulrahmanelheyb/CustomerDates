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

        public string Extras { get; set; }

    }
}
