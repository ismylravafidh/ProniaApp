using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Image
{
    public class ImageNullException : Exception
    {
        public ImageNullException():base("Image can't be empty")
        {
        }
        public ImageNullException(string? message) : base(message)
        {
        }
    }
}
