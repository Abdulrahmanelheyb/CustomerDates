using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SoftwarePart
    {
        public int ID { get; set; }
        public string Parttype { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
    }
}
