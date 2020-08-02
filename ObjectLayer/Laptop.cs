using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class Laptop : Device
    {
        public Laptop()
        {

        }
        public static DataTable Laptops = new DataTable();
        public static DataTable LaptopsProperty
        {
            get
            {
                return Laptops;
            }
            set
            {
                LaptopsProperty = Laptops;
            }
        }

        public string Extras { get; set; }

        public static Laptop GetLaptop(int RowIndex)
        {
            Laptop laptop = new Laptop();
            laptop.DeviceInformationCode = Laptops.Rows[RowIndex][0].ToString();
            laptop.SerialNumber = Laptops.Rows[RowIndex][1].ToString();
            laptop.CustomerName = Laptops.Rows[RowIndex][2].ToString();
            laptop.CustomerPhoneNumber = Laptops.Rows[RowIndex][3].ToString();
            laptop.Extras = Laptops.Rows[RowIndex][4].ToString();
            laptop.DeviceCompany = Laptops.Rows[RowIndex][5].ToString();
            laptop.Model = Laptops.Rows[RowIndex][6].ToString();
            laptop.Price = int.Parse(Laptops.Rows[RowIndex][7].ToString());
            laptop.Date = Convert.ToDateTime(Laptops.Rows[RowIndex][8].ToString());
            laptop.Hardwares = Laptops.Rows[RowIndex][10].ToString();
            laptop.Softwares = Laptops.Rows[RowIndex][11].ToString();
            return laptop;
        }
    }
}
