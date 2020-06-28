using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerDates.MainWindowControls
{
    /// <summary>
    /// Interaction logic for DockPanelLeft.xaml
    /// </summary>
    public partial class DockPanelLeft : UserControl
    {
        public DockPanelLeft()
        {
            InitializeComponent();
        }

        private void homebtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        public virtual void Comp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("helo");
        }
    }
}
