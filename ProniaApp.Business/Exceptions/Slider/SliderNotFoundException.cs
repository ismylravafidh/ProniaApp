using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Slider
{
    public class SliderNotFoundException : Exception
    {
        public SliderNotFoundException() : base("No such Slider was found")
        {
        }

        public SliderNotFoundException(string? message) : base(message)
        {
        }
    }
}
