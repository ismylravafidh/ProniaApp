using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Category
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() : base("No such Category was found")
        {
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
        }
    }
}
