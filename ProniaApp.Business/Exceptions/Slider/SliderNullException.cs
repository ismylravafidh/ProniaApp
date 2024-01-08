using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Slider
{
    public class SliderNullException : Exception
    {
        public SliderNullException() : base("Slider can't be empty")
        {
        }

        public SliderNullException(string? message) : base(message)
        {
        }
    }
}
