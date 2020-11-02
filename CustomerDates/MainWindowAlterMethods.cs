using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CustomerDates
{
    /// <summary>
    /// This class linked with mainwindow class is partial class has methods .
    /// </summary>
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

        public void setRequestedMenuTool(Grid grid, UserControl usercontrol)
        {
            grid.Children.Add(usercontrol);
        }
    }
}
