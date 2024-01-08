using AutoMapper;
using BlogApp.Business.Helpers;
using Microsoft.EntityFrameworkCore;
using ProniaApp.Business.DTOs.ProductDtos;
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
    public class ProductService : IProductService
    {
        private readonly IProductImageRepository _imageRepository;
        IProductRepository _repository;
        IProductTagRepository _tagRepository;
        IProductImageService _imageService;
        IProductTagService _tagService;
        IMapper _mapper;
        public ProductService(IProductImageRepository imageRepository,IProductRepository repository,IProductTagRepository _tagRepository, IMapper mapper, IProductImageService ImageService,IProductTagService TagService)
        {
            _imageRepository = imageRepository;
            _repository = repository;
            _tagRepository = _tagRepository;
            _mapper = mapper;
            _imageService = ImageService;
            _tagService = TagService;
        }
        public async Task<IQueryable<Product>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Product product = await _repository.GetByIdAsync(id);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            return product;
        }
        public async Task Create(ProductCreateDto entity, string env)
        {
            if (entity is null)
            {
                throw new ProductNullException();
            }
            bool resultCategory = await _repository.Table.AnyAsync(c => c.Id == entity.CategoryId);
            if (!resultCategory)
            {
                throw new CategoryNotFoundException();
            }
            Product product = _mapper.Map<Product>(entity);
            if (entity.TagIds != null)
            {
                foreach (int tagId in entity.TagIds)
                {
                    bool resultTag = await _repository.Table.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        throw new TagNotFoundException();
                    }
                    ProductTag productTag = new ProductTag()
                    {
                        Product = product,
                        TagId = tagId,
                    };
                    await _tagService.Create(productTag);
                }
            }
            ProductImage mainImage = new ProductImage()
            {
                IsPrime = true,
                ImgUrl = entity.MainPhoto.Upload(env, @"\Upload\ProductImage\"),
                Product = product,
            };
            ProductImage hoverImage = new ProductImage()
            {
                IsPrime = false,
                ImgUrl = entity.HoverPhoto.Upload(env, @"\Upload\ProductImage\"),
                Product = product,
            };
            await _imageService.Create(mainImage);
            await _imageService.Create(hoverImage);
            if (entity.Photos != null)
            {
                foreach (var item in entity.Photos)
                {

                    ProductImage newPhoto = new ProductImage()
                    {
                        IsPrime = null,
                        ImgUrl = item.Upload(env, @"\Upload\ProductImage\"),
                        Product = product,
                    };
                    await _imageService.Create(newPhoto);
                }
            }
            await _repository.Create(product);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(ProductUpdateDto entity, string env)
        {
            if (entity is null)
            {
                throw new ProductNullException();
            }
            Product oldProduct = await _repository.Table.Where(p => p.IsPrime == false).Include(p=>p.ProductImages).Include(p=>p.ProductTags).Where(p=>p.Id == entity.Id).FirstOrDefaultAsync();
            if (oldProduct is null)
            {
                throw new ProductNotFoundException();
            }
            bool resultCategory = await _repository.Table.AnyAsync(c => c.Id == entity.CategoryId);
            if (!resultCategory)
            {
                throw new CategoryNotFoundException();
            }
            _mapper.Map(entity, oldProduct);
            if (entity.TagIds != null)
            {
                foreach (int tagId in entity.TagIds)
                {
                    bool resultTag = await _repository.Table.AnyAsync(c => c.Id == tagId);
                    if (!resultTag)
                    {
                        throw new TagNotFoundException();
                    }
                }
                List<int> createTags;
                if (oldProduct.ProductTags != null)
                {
                    createTags = entity.TagIds.Where(ti => !oldProduct.ProductTags.Any(pt => pt.TagId == ti)).ToList();
                }
                else
                {
                    createTags = entity.TagIds.ToList();
                }
                foreach (int tagId in createTags)
                {
                    ProductTag productTag = new ProductTag()
                    {
                        TagId = tagId,
                        ProductId = oldProduct.Id
                    };
                    await _tagService.Create(productTag);
                }
                IEnumerable<ProductTag> removeTags = oldProduct.ProductTags.Where(pt => !entity.TagIds.Contains((int)pt.TagId));
                _tagService.RemoveRange(removeTags);
            }
            else
            {
                var productTagList = _tagRepository.Table.Where(p=>p.ProductId == oldProduct.Id).ToList();
                _tagService.RemoveRange(productTagList);
            }
            if (entity.MainPhoto != null)
            {
                ProductImage newMainImages = new ProductImage()
                {
                    IsPrime = true,
                    ProductId = oldProduct.Id,
                    ImgUrl = entity.MainPhoto.Upload(env, @"\Upload\ProductImage\")
                };
                var oldmainPhoto = oldProduct.ProductImages?.FirstOrDefault(p => p.IsPrime == true);
                oldProduct.ProductImages?.Remove(oldmainPhoto);
                oldProduct.ProductImages.Add(newMainImages);
            }
            if (entity.HoverPhoto != null)
            {
                ProductImage newHoverImages = new ProductImage()
                {
                    IsPrime = false,
                    ProductId = oldProduct.Id,
                    ImgUrl = entity.HoverPhoto.Upload(env, @"\Upload\ProductImage\")
                };
                var oldHoverPhoto = oldProduct.ProductImages?.FirstOrDefault(p => p.IsPrime == false);
                oldProduct.ProductImages?.Remove(oldHoverPhoto);
                oldProduct.ProductImages.Add(newHoverImages);
            }
            if (entity.Photos != null)
            {
                foreach (var item in entity.Photos)
                {
                    ProductImage newPhoto = new ProductImage()
                    {
                        IsPrime = null,
                        ImgUrl = item.Upload(env, @"\Upload\ProductImage\"),
                        Product = oldProduct,
                    };
                    oldProduct.ProductImages.Add(newPhoto);
                }
            }
            if (entity.ImageIds != null)
            {
                var removeListImage = oldProduct.ProductImages.Where(p => !entity.ImageIds.Contains(p.Id) && p.IsPrime == null).ToList();
                foreach (var item in removeListImage)
                {
                    oldProduct.ProductImages.Remove(item);
                    item.ImgUrl.DeleteFile(env, @"\Upload\ProductImage\");
                }
            }
            else
            {
                var images = _imageRepository.Table.Where(p => p.IsPrime == null);
                _imageRepository.RemoveRange(images);
            }

            await _repository.SaveChangesAsync();
        }
        public async void Delete(int id)
        {
            var product = _repository.Table.Where(p => p.IsPrime == false).FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            product.IsDeleted = true;
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }
    }
}
