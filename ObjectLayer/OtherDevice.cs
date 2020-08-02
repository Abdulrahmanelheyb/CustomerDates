using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class OtherDevice : Device
    {
        public OtherDevice()
        {

        }
        public static DataTable OtherDevices = new DataTable();

        public static DataTable OtherDevicesProperty
        {
            get { return OtherDevices; }
            set { OtherDevicesProperty = OtherDevices; }
        }

        public string Extras { get; set; }

        public static OtherDevice GetOtherDevice(int RowIndex)
        {
            OtherDevice otherdevice = new OtherDevice();
            otherdevice.DeviceInformationCode = OtherDevices.Rows[RowIndex][0].ToString();
            otherdevice.SerialNumber = OtherDevices.Rows[RowIndex][1].ToString();
            otherdevice.CustomerName = OtherDevices.Rows[RowIndex][2].ToString();
            otherdevice.CustomerPhoneNumber = OtherDevices.Rows[RowIndex][3].ToString();
            otherdevice.Extras = OtherDevices.Rows[RowIndex][4].ToString();
            otherdevice.DeviceCompany = OtherDevices.Rows[RowIndex][5].ToString();
            otherdevice.Model = OtherDevices.Rows[RowIndex][6].ToString();
            otherdevice.Price = int.Parse(OtherDevices.Rows[RowIndex][7].ToString());
            otherdevice.Date = Convert.ToDateTime(OtherDevices.Rows[RowIndex][8].ToString());
            otherdevice.Hardwares = OtherDevices.Rows[RowIndex][10].ToString();
            otherdevice.Softwares = OtherDevices.Rows[RowIndex][11].ToString();
            return otherdevice;
        }





    }
}
