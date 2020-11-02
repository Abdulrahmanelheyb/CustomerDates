using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    /// <summary>
    /// This Tablet Basic Class.
    /// </summary>
    public class Tablet : Device
    {   
        public Tablet()
        {

        }
        public static DataTable Tablets = new DataTable();

        public static DataTable TabletsProperty
        {
            get { return Tablets; }
            set { TabletsProperty = Tablets; }
        }

        public string Extras { get; set; }

        public static Tablet GetTablet(int RowIndex)
        {
            Tablet tablet = new Tablet();
            tablet.DeviceInformationCode = Tablets.Rows[RowIndex][0].ToString();
            tablet.SerialNumber = Tablets.Rows[RowIndex][1].ToString();
            tablet.CustomerName = Tablets.Rows[RowIndex][2].ToString();
            tablet.CustomerPhoneNumber = Tablets.Rows[RowIndex][3].ToString();
            tablet.Extras = Tablets.Rows[RowIndex][4].ToString();
            tablet.DeviceCompany = Tablets.Rows[RowIndex][5].ToString();
            tablet.Model = Tablets.Rows[RowIndex][6].ToString();
            tablet.Price = int.Parse(Tablets.Rows[RowIndex][7].ToString());
            tablet.Date = Convert.ToDateTime(Tablets.Rows[RowIndex][8].ToString());
            tablet.Hardwares = Tablets.Rows[RowIndex][10].ToString();
            tablet.Softwares = Tablets.Rows[RowIndex][11].ToString();
            return tablet;
        }


    }
}
