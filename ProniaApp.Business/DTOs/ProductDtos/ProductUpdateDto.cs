using Microsoft.AspNetCore.Http;
using ProniaApp.Business.DTOs.BaseDtos;
using ProniaApp.Business.DTOs.ProductImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.ProductDtos
{
    public class ProductUpdateDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool? IsPrime { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<int>? TagIds { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public ICollection<IFormFile>? Photos { get; set; }
        public ICollection<ProductImagesDto>? productImages { get; set; }
        public ICollection<int>? ImageIds { get; set; }
    }
}
