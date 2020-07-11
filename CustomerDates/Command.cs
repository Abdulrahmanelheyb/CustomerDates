using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomerDates
{
    class Command : ICommand
    {
        Action<object> ExecuteMethod;
        Func<object, bool> CanExecuteMethod;

        public Command(Action<object> ExecuteMethod , Func<object, bool> CanExecuteMethod)
        {
            this.ExecuteMethod = ExecuteMethod;
            this.CanExecuteMethod = CanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            CanExecuteMethod(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
