using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Image
{
    public class ImageMaxLengthException : Exception
    {
        public ImageMaxLengthException():base("You can download a maximum of 3 MB")
        {
        }

        public ImageMaxLengthException(string? message) : base(message)
        {
        }
    }
}
