using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities.Common
{
    public record BaseAuditable : BaseEntity
    {
        public bool? IsDeleted { get; set; }
    }
}
