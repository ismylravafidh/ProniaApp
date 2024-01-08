using ProniaApp.Business.DTOs.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : BaseEntityDto
    {
        public string Name { get; set; }
    }
}
