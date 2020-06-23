using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLayer;
using System.Data.SQLite;

namespace DataManagement
{
    public class Load
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad;
        private static SQLiteDataReader dare;
        public static bool LoadComputers()
        {
            bool loadresult = false;
            try
            {

            }catch(Exception)
            {
                
            }
            return loadresult;
        }
        public static bool LoadLaptops()
        {
            bool loadresult = false;
            try
            {

            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadMobiles()
        {
            bool loadresult = false;
            try
            {

            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadTablets()
        {
            bool loadresult = false;
            try
            {

            }
            catch (Exception)
            {

            }
            return loadresult;
        }
        public static bool LoadOtherDevices()
        {
            bool loadresult = false;
            try
            {

            }
            catch (Exception)
            {

            }
            return loadresult;
        }
    }
}
