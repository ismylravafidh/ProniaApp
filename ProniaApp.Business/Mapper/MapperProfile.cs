using AutoMapper;
using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.DTOs.ProductDtos;
using ProniaApp.Business.DTOs.ProductImageDtos;
using ProniaApp.Business.DTOs.TagDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<Product, ProductCreateDto>();
            CreateMap<Product, ProductCreateDto>().ReverseMap();

            CreateMap<Tag, TagCreateDto>();
            CreateMap<Tag, TagCreateDto>().ReverseMap();
        }
    }
}
