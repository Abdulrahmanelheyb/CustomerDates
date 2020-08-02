using DataManagement;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDates.ViewModel.TabletServices
{
    public class TabletData
    {
        public static bool InsertTablet(Tablet tablet)
        {
            bool result = false;
            try
            {
                UniqueCode.GetCode(tablet);
                result = Insert.InsertDevice(tablet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static bool UpdateTablet(Tablet tablet)
        {
            bool result = false;
            try
            {
                result = Update.UpdateDevice(tablet);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public static void DeleteTablet(Tablet tablet)
        {
            Delete.Delete_Device(tablet);
            LoadTablet();
        }

        public static bool LoadTablet()
        {
            return Load.LoadTablets();

        }

        public static DataTable SearchTablet()
        {
            return Tablet.Tablets;
        }

        public static DataView SearchTablet(string Type, string Value)
        {
            DataView dv = Tablet.Tablets.DefaultView;
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
