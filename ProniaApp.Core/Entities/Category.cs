using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record Category : BaseAuditable
    {
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
