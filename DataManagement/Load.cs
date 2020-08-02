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
    public class Load
    {
        private static SQLiteCommand cmd;
        private static SQLiteDataAdapter daad = null;
        public static bool LoadComputers()
        {
            bool loadresult = false;
            
            try
            {
                SharedFields.con.Open();
                if(SharedFields.con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Computers", SharedFields.con);

                    daad = new SQLiteDataAdapter(cmd);
                    Computer.Computers.Clear();
                    daad.Fill(Computer.Computers);
                    SharedFields.con.Close();
                    loadresult = true;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return loadresult;
        }
        public static bool LoadLaptop()
        {
            bool loadresult = false;
            try
            {
                SharedFields.con.Open();
                if (SharedFields.con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("SELECT * FROM  Laptops", SharedFields.con);
                    daad = new SQLiteDataAdapter(cmd);
                    Laptop.Laptops.Clear();
                    daad.Fill(Laptop.Laptops);
                    SharedFields.con.Close();
                    loadresult = true;
                }
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
                SharedFields.con.Open();
                if (SharedFields.con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Mobiles", SharedFields.con);
                    daad = new SQLiteDataAdapter(cmd);
                    Mobile.Mobiles.Clear();
                    daad.Fill(Mobile.Mobiles);
                    SharedFields.con.Close();
                    loadresult = true;
                }
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
                SharedFields.con.Open();
                if (SharedFields.con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Tablets", SharedFields.con);
                    daad = new SQLiteDataAdapter(cmd);
                    Tablet.Tablets.Clear();
                    daad.Fill(Tablet.Tablets);
                    SharedFields.con.Close();
                    loadresult = true;
                }
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
                SharedFields.con.Open();
                if (SharedFields.con.State == ConnectionState.Open)
                {

                    cmd = new SQLiteCommand("SELECT * FROM  Otherdevices", SharedFields.con);
                    daad = new SQLiteDataAdapter(cmd);
                    OtherDevice.OtherDevices.Clear();
                    daad.Fill(OtherDevice.OtherDevices);
                    SharedFields.con.Close();
                    loadresult = true;
                }
            }
            catch (Exception)
            {

            }
            return loadresult;
        }
    }
}
