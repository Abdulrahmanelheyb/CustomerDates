using CustomerDates.DeviceControls;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CustomerDates.ViewModel.ComputerServices
{
    public class ComputerDataCommands
    {
        
        public ICommand Insert { get; set; }
        public ComputerDataCommands()
        {
            Insert = new Command(Execute, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }
        private void Execute(object parameter)
        {
            
        }
    }
}
