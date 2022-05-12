using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConverterStatic.Core.Commands
{
    public  class CoreCommand : ICommand
    {
        Action<object> _execute;
        Task _taskExecute;
        public event EventHandler? CanExecuteChanged;

        public CoreCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
