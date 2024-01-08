using AutoMapper;
using BlogApp.Business.Helpers;
using Microsoft.EntityFrameworkCore;
using ProniaApp.Business.DTOs.SliderDtos;
using ProniaApp.Business.Exceptions.Id;
using ProniaApp.Business.Exceptions.Image;
using ProniaApp.Business.Exceptions.Product;
using ProniaApp.Business.Exceptions.Slider;
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
    public class SliderService : ISliderService
    {
        ISliderRepository _repository;
        IMapper _mapper;
        public SliderService(ISliderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IQueryable<Slider>> GetAllAsync()
        {
            var sliders = await _repository.GetAllAsync();
            return sliders;
        }
        public async Task<Slider> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Slider slider = await _repository.GetByIdAsync(id);
            if (slider is null)
            {
                throw new SliderNotFoundException();
            }
            return slider;
        }
        public async Task Create(SliderCreateDto entity, string env)
        {
            if (!entity.Image.ContentType.Contains("image"))
            {
                throw new NotImageException();
            }
            if (entity.Image.Length > 3170304)
            {
                throw new ImageMaxLengthException();
            }
            entity.ImgUrl = entity.Image.Upload(env, @"\Upload\SliderImage\");

            var slider = _mapper.Map<Slider>(entity);
            await _repository.Create(slider);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(SliderUpdateDto entity, string env)
        {
            if (!entity.Image.ContentType.Contains("image"))
            {
                throw new NotImageException();
            }
            if (entity.Image.Length > 3170304)
            {
                throw new ImageMaxLengthException();
            }
            entity.ImgUrl = entity.Image.Upload(env, @"\Upload\SliderImage\");
            Slider oldSlider = _repository.Table.Find(entity.Id);
            FileManager.DeleteFile(oldSlider.ImgUrl, env, @"\Upload\SliderImage\");
            _mapper.Map(oldSlider,entity);
            await _repository.SaveChangesAsync();
        }
        public async void Delete(int id,string env)
        {
            Slider slider = _repository.Table.FirstOrDefault(s => s.Id == id);
            slider.IsDeleted=true;
            _repository.Delete(slider);
            await _repository.SaveChangesAsync();
            FileManager.DeleteFile(slider.ImgUrl, env, @"\Upload\SliderImage\");
        }
    }
}
