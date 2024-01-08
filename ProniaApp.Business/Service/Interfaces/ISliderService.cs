using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.DTOs.SliderDtos;
using ProniaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Interfaces
{
    public interface ISliderService
    {
        Task<IQueryable<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task Create(SliderCreateDto entity, string env);
        Task Update(SliderUpdateDto entity, string env);
        void Delete(int id,string env);
    }
}
