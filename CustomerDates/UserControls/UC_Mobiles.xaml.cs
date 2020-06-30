﻿using System;
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

namespace CustomerDates.UserControls
{
    /// <summary>
    /// Interaction logic for Computers.xaml
    /// </summary>
    public partial class UC_Mobiles : UserControl
    {
        public UC_Mobiles()
        {
            InitializeComponent();
        }
        public static string UCGetName()
        {
            return "Mobiles";
        }
        private void SearchIO_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.Visibility ==Visibility.Visible)
            {
                SearchPanel.Visibility = Visibility.Collapsed;
                MobilesListBox.Margin = new Thickness(33, 0, 0, 0);
            }
            else
            {
                SearchPanel.Visibility = Visibility.Visible;
                MobilesListBox.Margin = new Thickness(33,33, 0, 0);
            }
        }
    }
}