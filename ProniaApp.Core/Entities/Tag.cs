using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record Tag : BaseAuditable
    {
        public string Name { get; set; }
        public ICollection<ProductTag>? ProductTags { get; set; }
    }
}
