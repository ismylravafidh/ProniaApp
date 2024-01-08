using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record Setting : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
