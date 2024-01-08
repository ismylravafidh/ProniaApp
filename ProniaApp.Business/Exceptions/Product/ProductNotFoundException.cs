using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Product
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("No such Product was found")
        {
        }

        public ProductNotFoundException(string? message) : base(message)
        {
        }
    }
}
