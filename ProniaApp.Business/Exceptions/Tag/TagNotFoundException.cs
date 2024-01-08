using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Exceptions.Tag
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException() : base("No such Tag was found")
        {
        }

        public TagNotFoundException(string? message) : base(message)
        {
        }
    }
}
