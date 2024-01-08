using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.CategoryDtos
{
    public record CategoryCreateDto
    {
        public string Name { get; set; }
    }
}
