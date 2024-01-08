using Humanizer;
using Microsoft.AspNetCore.Mvc;
using ProniaApp.Business.DTOs.CategoryDtos;
using ProniaApp.Business.Service.Interfaces;
using ProniaApp.Core.Entities;

namespace ProniaApp.MVC.Areas.Manage.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _service;

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            await _service.Create(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update()
        {
            return View();
        }
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            await _service.Update(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
