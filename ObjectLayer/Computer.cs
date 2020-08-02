using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ObjectLayer
{
    public class Computer : Device
    {
        public Computer()
        {
            
        }
        public static DataTable Computers = new DataTable();

        
        public static DataTable ComputersProperty
        {
            get
            {
                return Computers;
            }
            set
            {
                ComputersProperty = Computers;
            }
        }

        public static Computer GetComputer(int RowIndex)
        {
            Computer computer = new Computer();
            computer.DeviceInformationCode = Computers.Rows[RowIndex][0].ToString();
            computer.SerialNumber = Computers.Rows[RowIndex][1].ToString();
            computer.CustomerName = Computers.Rows[RowIndex][2].ToString();
            computer.CustomerPhoneNumber = Computers.Rows[RowIndex][3].ToString();
            // computer.Extras = Computers.Rows[RowIndex][4].ToString();
            computer.DeviceCompany = Computers.Rows[RowIndex][4].ToString();
            computer.Model = Computers.Rows[RowIndex][5].ToString();
            computer.Price = int.Parse(Computers.Rows[RowIndex][6].ToString());
            computer.Date = Convert.ToDateTime(Computers.Rows[RowIndex][7].ToString());
            computer.Hardwares = Computers.Rows[RowIndex][9].ToString();
            computer.Softwares = Computers.Rows[RowIndex][10].ToString();
            return computer;
        }


    }
}
