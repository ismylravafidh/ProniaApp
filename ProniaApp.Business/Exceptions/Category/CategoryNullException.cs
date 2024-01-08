using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Category
{
    public class CategoryNullException : Exception
    {
        public CategoryNullException():base("Category can't be empty")
        {
        }

        public CategoryNullException(string? message) : base(message)
        {
        }
    }
}
