using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{

    /// <summary>
    /// This Mobile Basic Class.
    /// </summary>
    public class Mobile : Device
    {
        public Mobile()
        {

        }
        public static DataTable Mobiles = new DataTable();

        public static DataTable MobilesProperty
        {
            get
            {
                return Mobiles;
            }
            set
            {
                MobilesProperty = Mobiles;
            }
        }

        public string Extras { get; set; }

        public static Mobile GetMobile(int RowIndex)
        {
            Mobile mobile = new Mobile();
            mobile.DeviceInformationCode = Mobiles.Rows[RowIndex][0].ToString();
            mobile.SerialNumber = Mobiles.Rows[RowIndex][1].ToString();
            mobile.CustomerName = Mobiles.Rows[RowIndex][2].ToString();
            mobile.CustomerPhoneNumber = Mobiles.Rows[RowIndex][3].ToString();
            mobile.Extras = Mobiles.Rows[RowIndex][4].ToString();
            mobile.DeviceCompany = Mobiles.Rows[RowIndex][5].ToString();
            mobile.Model = Mobiles.Rows[RowIndex][6].ToString();
            mobile.Price = int.Parse(Mobiles.Rows[RowIndex][7].ToString());
            mobile.Date = Convert.ToDateTime(Mobiles.Rows[RowIndex][8].ToString());
            mobile.Hardwares = Mobiles.Rows[RowIndex][10].ToString();
            mobile.Softwares = Mobiles.Rows[RowIndex][11].ToString();
            return mobile;
        }

    }
}
