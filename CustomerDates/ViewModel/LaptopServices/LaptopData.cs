using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using DataManagement;

namespace CustomerDates.ViewModel.LaptopServices
{
    public class LaptopData
    {
        public static bool LoadLaptop()
        {
            try
            {
                return Load.LoadLaptops();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
