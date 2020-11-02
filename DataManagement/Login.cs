using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.CodeDom;

namespace DataManagement
{
    /// <summary>
    /// This Class is Login User if check value from database (MySQL)
    /// </summary>
    public class Login
    {
        private static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        private static SQLiteCommand cmd;
        private static SQLiteDataReader dare;

        public static bool LoginUser(string user,string password)
        {
            bool Loginresult = false;
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    cmd = new SQLiteCommand("SELECT * FROM Users",con);
                    dare = cmd.ExecuteReader();
                    while (dare.Read())
                    {
                        if (user == dare.GetString(1) && password == dare.GetString(2))
                        {
                            Loginresult = true;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Loginresult;
        }
    }
}
