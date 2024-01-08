using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record ProductTag : BaseEntity
    {
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
