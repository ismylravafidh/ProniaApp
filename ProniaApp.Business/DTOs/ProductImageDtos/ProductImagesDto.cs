using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.ProductImageDtos
{
    public class ProductImagesDto
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public bool? IsPrime { get; set; }
    }
}
