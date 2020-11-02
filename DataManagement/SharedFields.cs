using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DataManagement
{
    /// <summary>
    /// This Class has SuperGlobals Variables.
    /// </summary>
    public class SharedFields
    {
        public const string DBPath = @"Data Source = Data\CustomerDates.sl3;Version=3;";
        public static SQLiteConnection con = new SQLiteConnection(SharedFields.DBPath);
        
    }
}
