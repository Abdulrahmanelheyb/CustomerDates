using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLayer;
using System.Data.SQLite;
using System.Data;

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

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }

        public static bool SearchDevice(Laptop Laptop)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if(con.State == ConnectionState.Open)
                {


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {
    
            }

            return searchresult;
        }

        public static bool SearchDevice(Mobile Mobile)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }

        public static bool SearchDevice(Tablet Tablet)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }
        public static bool SearchDevice(OtherDevice OtherDevice)
        {
            bool searchresult = false;

            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {


                    con.Close();
                    searchresult = true;
                }
            }
            catch (Exception)
            {

            }

            return searchresult;
        }


    }
}
