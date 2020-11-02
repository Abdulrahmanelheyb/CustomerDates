using DataManagement;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDates.ViewModel.MobileServices
{
    public class MobileData
    {
        public static bool InsertMobile(Mobile mobile)
        {
            bool result = false;
            try
            {
                mobile.ValidateData();
                mobile.GenerateDeviceInformationCode(Device.DeviceType.MOB);
                result = Insert.InsertDevice(mobile);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static bool UpdateMobile(Mobile mobile)
        {
            bool result = false;
            try
            {
                result = Update.UpdateDevice(mobile);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static void DeleteMobile(Mobile mobile)
        {
            Delete.Delete_Device(mobile);
            LoadMobile();
        }

        public static bool LoadMobile()
        {
            return Load.LoadMobiles();

        }

        public static DataView SearchMobile(string Type, string Value)
        {
            DataView dv = Mobile.Mobiles.DefaultView;
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
