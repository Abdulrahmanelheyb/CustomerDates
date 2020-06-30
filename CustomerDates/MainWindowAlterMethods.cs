using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CustomerDates
{
    public partial class MainWindow
    {
        public void MainWindowAlterMethods()
        {

        }

        public void SetUserControl(Grid Grid,UserControl Usercontrol)
        {
            Grid.Children.Clear();
            Grid.Children.Add(Usercontrol);
        }
    }
}
