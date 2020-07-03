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

namespace CustomerDates.DeviceControls
{
    /// <summary>
    /// Interaction logic for Computers.xaml
    /// </summary>
    public partial class TabletsManager : UserControl
    {
        public TabletsManager()
        {
            InitializeComponent();
        }
        public static string UCGetName()
        {
            return "Tablets";
        }
        private void SearchIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility ==Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                TabletsListBox.Margin = new Thickness(33, 0, 0, 0);
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                TabletsListBox.Margin = new Thickness(33,33, 0, 0);
            }
        }
    }
}
