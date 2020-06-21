using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CustomerDates.Classes
{
    public class MainWindowMethods
    {
        public static bool ViewControl_DataGrid(Grid grd, System.Windows.Controls.Control ctrl)
        {
            grd.Children.Clear();
            grd.Children.Add(ctrl);

            CheckBooleans.b_computer = default;
            CheckBooleans.b_laptop = default;
            CheckBooleans.b_mobile = default;
            CheckBooleans.b_tablet = default;
            CheckBooleans.b_otherdevice = default;
            return true;
        }

    }
}
