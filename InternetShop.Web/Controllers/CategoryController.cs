using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;
using InternetShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            var model = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return View();

            var category = new Category
            {
                Name = categoryViewModel.Name,
            };
            _categoryRepository.Add(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var category = _categoryRepository.GetById(id);
            var model = new CategoryViewModel { Name = category.Name };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return View(categoryViewModel);

            var category = new Category { Name = categoryViewModel.Name, Id = categoryViewModel.Id };
            _categoryRepository.Update(category);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) { 
            var category = _categoryRepository.GetById(id);

           _categoryRepository.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
