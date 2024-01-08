using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Tag
{
    public class TagNullException : Exception
    {
        public TagNullException() : base("Tag can't be empty")
        {
        }

        public TagNullException(string? message) : base(message)
        {
        }
    }
}
