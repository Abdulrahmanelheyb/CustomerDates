using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDates.UserControls;
using ObjectLayer;

namespace CustomerDates.Classes
{
    public class ComputerUI : Computer
    {
        public static List<DeviceRow> DeviceRows = new List<DeviceRow>();
        public static void GetComputerRows()
        {
            
            foreach (Computer comp in Computers)
            {
                DeviceRow computerrow = new DeviceRow();
                computerrow.CustomerName.Content = comp.CustomerName;
                computerrow.CustomerPhoneNumber.Content = comp.CustomerPhoneNumber;
                computerrow.DeviceCompany.Content = comp.DeviceCompany;
                computerrow.Model.Content = comp.Model;
                computerrow.SerialNumber.Content = comp.SerialNumber;
                computerrow.Price.Content = comp.Price;
                computerrow.DeviceInformationCode.Content = comp.DeviceInformationCode;
                computerrow.Date.Content = comp.Date;
                ComputerUI.DeviceRows.Add(computerrow);

            }
        }
    }
}
