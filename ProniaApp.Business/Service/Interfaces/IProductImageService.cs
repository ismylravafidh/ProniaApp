using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImage> GetByIdAsync(int id);
        Task Create(ProductImage entity);
        void RemoveRange(IQueryable<ProductImage> entities);
        void Remove(int id);
    }
}
