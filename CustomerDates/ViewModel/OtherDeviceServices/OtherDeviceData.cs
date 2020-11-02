using DataManagement;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDates.ViewModel.OtherDeviceServices
{
    public class OtherDeviceData
    {
        public static bool InsertOtherDevice(OtherDevice otherdevice)
        {
            bool result = false;
            try
            {
                otherdevice.ValidateData();
                otherdevice.GenerateDeviceInformationCode(Device.DeviceType.OTH);
                result = Insert.InsertDevice(otherdevice);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool UpdateOtherDevice(OtherDevice otherdevice)
        {
            bool result = false;
            try
            {
                result = Update.UpdateDevice(otherdevice);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static void DeleteOtherDevice(OtherDevice otherdevice)
        {
            Delete.Delete_Device(otherdevice);
            LoadOtherDevice();
        }

        public static bool LoadOtherDevice()
        {
            return Load.LoadOtherDevices();

        }
        public static DataView SearchOtherDevice(string Type, string Value)
        {
            DataView dv = OtherDevice.OtherDevices.DefaultView;
            if (Type == "Name")
            {
                dv.RowFilter = "CustomerName LIKE '%" + Value + "%'";
            }
            if (Type == "PhoneNumber")
            {
                dv.RowFilter = "PhoneNumber LIKE '%" + Value + "%'";
            }
            if (Type == "DeviceCompany")
            {
                dv.RowFilter = "DeviceCompany LIKE '%" + Value + "%'";
            }
            if (Type == "SerialNumber")
            {
                dv.RowFilter = "SerialNumber LIKE '%" + Value + "%'";
            }
            if (Type == "Model")
            {
                dv.RowFilter = "DeviceModel LIKE '%" + Value + "%'";
            }
            if (Type == "DeviceInformationCode")
            {
                dv.RowFilter = "DeviceInformationCode LIKE '%" + Value + "%'";
            }
            return dv;
        }
    }
}
