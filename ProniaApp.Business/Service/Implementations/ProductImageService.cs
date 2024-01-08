using ProniaApp.Business.Exceptions.Id;
using ProniaApp.Business.Exceptions.Image;
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
    public class ProductImageService : IProductImageService
    {
        IProductImageRepository _repository;
        public ProductImageService(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductImage> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            ProductImage productImage = await _repository.GetByIdAsync(id);
            if (productImage is null)
            {
                throw new ImageNotFoundException();
            }
            return productImage;
        }
        public async Task Create(ProductImage entity)
        {
            await _repository.Create(entity);
            await _repository.SaveChangesAsync();
        }
        public async void Remove(int id)
        {
            ProductImage productImage = await GetByIdAsync(id);
            _repository.Remove(productImage);
            await _repository.SaveChangesAsync();
        }

        public async void RemoveRange(IQueryable<ProductImage> entities)
        {
            _repository.RemoveRange(entities);
            await _repository.SaveChangesAsync();
        }
    }
}
