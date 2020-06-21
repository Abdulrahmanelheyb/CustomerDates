using CustomerDates.Classes;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace CustomerDates
{
    /// <summary>
    /// Interaction logic for LoadScreen.xaml
    /// </summary>
    public partial class LoadScreen : Window
    {
        public LoadScreen()
        {

            InitializeComponent();
        }

        

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loadings.CheckIfDatabaseAvailable();
            progressbarduration();
            DataManagment.LoadUsers();

        }
        #region Progress Bar Methods >>>>
        DispatcherTimer dct = new DispatcherTimer();
        private void progressbarduration()
        {
            
            dct.Interval = new TimeSpan(200000);
            dct.Tick += Dct_Tick;
            dct.Start();

        }

        private void Dct_Tick(object sender, EventArgs e)
        {
            if(loadproc.Value != 100)
            {
                loadproc.Value += 1;
            }else
            {
                dct.Stop();
            }
        }

        private void loadproc_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            if (loadproc.Value == 100)
            {
                Login lgn = new Login();
                Close();
                lgn.Show();
            }
            if(loadproc.Value > 75)
            {
                if(Loadings.Checkexpyd() == true && Loadings.Checkdevslmt() == true)
                {
                    Environment.Exit(0);
                }
            }
        }
        #endregion
    }
}
