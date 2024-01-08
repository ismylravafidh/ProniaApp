using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.DTOs.ProductDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task Create(ProductCreateDto entity, string env);
        Task Update(ProductUpdateDto entity, string env);
        void Delete(int id);
    }
}
