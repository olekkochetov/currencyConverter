using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterStatic.Core.Commands
{
    public class ClearCommand : CoreCommand
    {
        public ClearCommand(Action<object> execute) : base(execute){}
    }
}
