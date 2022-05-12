using CurrencyConverterStatic.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConverterStatic.ViewModels
{
    public class ConvertCommand : CoreCommand
    {
        public ConvertCommand(Action<object> execute) : base(execute){}
    }
}
