using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.ProductTag
{
    public class ProductTagNotFoundException : Exception
    {
        public ProductTagNotFoundException():base("No such ProductTag was found")
        {
        }

        public ProductTagNotFoundException(string? message) : base(message)
        {
        }
    }
}
