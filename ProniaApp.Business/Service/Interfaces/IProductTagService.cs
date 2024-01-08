using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface IProductTagService
    {
        Task<ProductTag> GetByIdAsync(int id);
        Task Create(ProductTag entity);
        void RemoveRange(IEnumerable<ProductTag> entities);
        void Remove(int id);
    }
}
