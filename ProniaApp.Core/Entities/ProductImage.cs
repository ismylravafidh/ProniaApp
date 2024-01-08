using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record ProductImage : BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool? IsPrime { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
