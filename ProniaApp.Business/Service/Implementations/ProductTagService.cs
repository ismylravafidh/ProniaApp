using Microsoft.EntityFrameworkCore;
using ProniaApp.Business.Exceptions.Id;
using ProniaApp.Business.Exceptions.Product;
using ProniaApp.Business.Exceptions.ProductTag;
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
    public class ProductTagService : IProductTagService
    {
        IProductTagRepository _repository;
        public ProductTagService(IProductTagRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductTag> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            ProductTag productTag = await _repository.GetByIdAsync(id);
            if (productTag is null)
            {
                throw new ProductTagNotFoundException();
            }
            return productTag;
        }
        public async Task Create(ProductTag entity)
        {
            await _repository.Create(entity);
            await _repository.SaveChangesAsync();
        }
        public async void RemoveRange(IEnumerable<ProductTag> tags)
        {
            _repository.RemoveRange(tags);
            await _repository.SaveChangesAsync();
        }

        public async void Remove(int id)
        {
            ProductTag productTag = await GetByIdAsync(id);
            _repository.Remove(productTag);
            await _repository.SaveChangesAsync();
        }
    }
}
