using AutoMapper;
using BlogApp.Business.Helpers;
using Microsoft.EntityFrameworkCore;
using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.Exceptions.Category;
using ProniaApp.Business.Exceptions.Id;
using ProniaApp.Business.Service.Interfaces;
using ProniaApp.Core.Entities;
using ProniaApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.Business.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repository;
        IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IQueryable<Category>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Category category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                throw new CategoryNotFoundException();
            }
            return category;
        }

        public async Task Create(CategoryCreateDto entity)
        {
            if (entity is null)
            {
                throw new CategoryNullException();
            }
            Category category = _mapper.Map<Category>(entity);
            await _repository.Create(category);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(CategoryUpdateDto entity)
        {
            if (entity.Id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Category oldCategory =await GetByIdAsync(entity.Id);
            if (oldCategory is null)
            {
                throw new CategoryNotFoundException();
            }
            _mapper.Map(entity, oldCategory);
            await _repository.Update(oldCategory);
            await _repository.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Category category = await GetByIdAsync(id);
            if (category is null)
            {
                throw new CategoryNotFoundException();
            }
            category.IsDeleted = true;
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }
    }
}
