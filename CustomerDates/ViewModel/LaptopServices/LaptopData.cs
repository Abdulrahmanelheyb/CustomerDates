using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using DataManagement;
using ObjectLayer;

namespace CustomerDates.ViewModel.LaptopServices
{
    public class LaptopData
    {
        public static bool LoadLaptop()
        {
            try
            {
                return Load.LoadLaptop();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool InsertLaptop(Laptop laptop)
        {
            try
            {
                UniqueCode.GetCode(laptop);
                return Insert.InsertDevice(laptop);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool UpdateLaptop(Laptop laptop)
        {
            try
            {
                return Update.UpdateDevice(laptop);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteLaptop(Laptop laptop)
        {
            try
            {
                Delete.Delete_Device(laptop);
                LoadLaptop();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
