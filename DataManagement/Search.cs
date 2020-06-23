using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLayer;
using System.Data.SQLite;

namespace DataManagement
{
    public class Search
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad;
        private static SQLiteDataReader dare;
        public static bool SearchDevice(Computer Computer)
        {
            bool searchresult = false;


            return searchresult;
        }

        public static bool SearchDevice(Laptop Laptop)
        {
            bool searchresult = false;


            return searchresult;
        }

        public static bool SearchDevice(Mobile Mobile)
        {
            bool searchresult = false;


            return searchresult;
        }

        public static bool SearchDevice(Tablet Tablet)
        {
            bool searchresult = false;


            return searchresult;
        }
        public static bool SearchDevice(OtherDevice OtherDevice)
        {
            bool searchresult = false;


            return searchresult;
        }


    }
}
