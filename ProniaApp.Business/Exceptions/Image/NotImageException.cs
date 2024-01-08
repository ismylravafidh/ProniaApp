using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Image
{
    public class NotImageException : Exception
    {
        public NotImageException():base("You Can Only Upload Image.")
        {
        }

        public NotImageException(string? message) : base(message)
        {
        }
    }
}
