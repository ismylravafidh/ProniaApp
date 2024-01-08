using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record Product : BaseAuditable
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool? IsPrime { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductTag>? ProductTags { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}
