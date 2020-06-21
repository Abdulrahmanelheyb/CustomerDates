using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Data.SQLite;

namespace CustomerDates.Classes
{
     public class Loadings
     {
        public static void CheckIfDatabaseAvailable()
        {
            if (!File.Exists(@"Data\CustomerDates.sl3"))
            {
                MessageBox.Show("Database not found !");
                Environment.Exit(0);
            }
        }

        public static bool Checkdevslmt()
        {
            bool chk = false;
            SQLiteConnection con = new SQLiteConnection(Globals.DBPath);
            try
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT Devcount FROM sysure WHERE CDID='CD1'", con);
                SQLiteDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    var text = read.GetInt32(0);
                    if (text == 100)
                    {
                        chk = true;
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("|ERROR-DB| \n" + ex.Message);
            }
            return chk;
        }

        #region controlH
        public static bool Checkexpyd()
        {
            bool exp = false;
            SQLiteConnection con = new SQLiteConnection(Globals.DBPath);
            try
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT Expirydate FROM sysure", con);
                SQLiteDataReader read = cmd.ExecuteReader();
                while(read.Read())
                {
                    string text = read.GetString(0);
                    if(Convert.ToDateTime(text) <= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        exp = true;
                    }
                }
                con.Close();

            }catch(Exception)
            {
                MessageBox.Show("|ERROR-DB| Not connected");
            }
            return exp;
        }
        
        #endregion
    }
}
