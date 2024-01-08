using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Core.Entities
{
    public record Slider : BaseAuditable
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
    }
}