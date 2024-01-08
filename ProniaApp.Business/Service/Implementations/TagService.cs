using AutoMapper;
using ProniaApp.Business.DTOs.TagDtos;
using ProniaApp.Business.Exceptions.Category;
using ProniaApp.Business.Exceptions.Id;
using ProniaApp.Business.Exceptions.Product;
using ProniaApp.Business.Exceptions.Tag;
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
    public class TagService : ITagService
    {
        ITagRepository _repository;
        IMapper _mapper;
        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IQueryable<Tag>> GetAllAsync()
        {
            var tags = await _repository.GetAllAsync();
            return tags;
        }
        public async Task<Tag> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null)
            {
                throw new TagNotFoundException();
            }
            return tag;
        }

        public async Task Create(TagCreateDto entity)
        {
            if (entity is null)
            {
                throw new CategoryNullException();
            }
            Tag tag = _mapper.Map<Tag>(entity);
            await _repository.Create(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(TagUpdateDto entity)
        {
            if (entity.Id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Tag oldTag = await GetByIdAsync(entity.Id);
            if (oldTag is null)
            {
                throw new TagNotFoundException();
            }
            _mapper.Map(entity, oldTag);
            await _repository.Update(oldTag);
            await _repository.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Tag tag = await GetByIdAsync(id);
            if (tag is null)
            {
                throw new CategoryNotFoundException();
            }
            tag.IsDeleted = true;
            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }
    }
}
