using Microsoft.AspNetCore.Http;
using ProniaApp.Business.DTOs.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.DTOs.SliderDtos
{
    public class SliderUpdateDto : BaseEntityDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
