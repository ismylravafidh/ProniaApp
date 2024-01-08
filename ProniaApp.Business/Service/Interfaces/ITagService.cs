using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.DTOs.TagDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface ITagService
    {
        Task<IQueryable<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task Create(TagCreateDto entity);
        Task Update(TagUpdateDto entity);
        void Delete(int id);
    }
}
