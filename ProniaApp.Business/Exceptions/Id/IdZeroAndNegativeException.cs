using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Id
{
    public class IdZeroAndNegativeException : Exception
    {
        public IdZeroAndNegativeException():base("Id can't be Zero/Negative ")
        {
        }

        public IdZeroAndNegativeException(string? message) : base(message)
        {
        }
    }
}
