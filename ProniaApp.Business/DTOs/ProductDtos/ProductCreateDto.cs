using Microsoft.AspNetCore.Http;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.ProductDtos
{
    public record ProductCreateDto
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool? IsPrime { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<int>? TagIds { get; set; }
        public IFormFile MainPhoto { get; set; }
        public IFormFile HoverPhoto { get; set; }
        public ICollection<IFormFile>? Photos { get; set; }
    }
}
