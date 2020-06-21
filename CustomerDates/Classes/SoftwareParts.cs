using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CustomerDates.Classes
{
    public class SoftwareParts
    {
        public static List<ComboBoxItem> parts = new List<ComboBoxItem>();
        public static int ID { get; set; }
        public static string Parttype { get; set; }
        public static string Description { get; set; }
        public static int Price { get; set; }
        public static int StatusID { get; set; }
        public static string Status { get; set; }


    }
}
