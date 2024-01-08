using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.ProductTag
{
    public class ProductTagNullException : Exception
    {
        public ProductTagNullException() : base("ProductTag can't be empty")
        {
        }

        public ProductTagNullException(string? message) : base(message)
        {
        }
    }
}
