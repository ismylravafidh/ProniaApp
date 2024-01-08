using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Image
{
    public class ImageNotFoundException : Exception
    {
        public ImageNotFoundException():base("No such Image was found")
        {
        }

        public ImageNotFoundException(string? message) : base(message)
        {
        }
    }
}
