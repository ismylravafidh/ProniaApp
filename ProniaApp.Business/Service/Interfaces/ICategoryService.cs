using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task Create(CategoryCreateDto entity);
        Task Update(CategoryUpdateDto entity);
        void Delete(int id);
    }
}