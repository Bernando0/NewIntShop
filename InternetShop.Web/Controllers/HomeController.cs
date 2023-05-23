using InternetShop.Application.Interfaces;
using InternetShop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternetShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, IConfiguration config, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _config = config;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var entity = _productRepository.GetProducts();
            var categories = _categoryRepository.GetAll();

            var model = new HomeViewModel
            {
                Products = entity.Select(e => new ProductViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Category = e.Category,
                    ApplicationType = e.ApplicationType,
                    Price = e.Price,
                    Image = _config["ImagePath"] + e.Image,
                }).ToList(),
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList()
            };
            return View(model);
        }


    }
}