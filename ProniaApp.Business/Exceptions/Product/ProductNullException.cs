using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Product
{
    public class ProductNullException : Exception
    {
        public ProductNullException() : base("Product can't be empty")
        {
        }

        public ProductNullException(string? message) : base(message)
        {
        }
    }
}
