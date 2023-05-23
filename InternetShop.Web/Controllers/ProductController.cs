using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;
using InternetShop.Web.Models;
using InternetShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;
        
        private readonly ImageService _imageService;

        public ProductController(IProductRepository productRepository, ImageService imageService, ProductService productService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();
            var model = products.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                Category = c.Category,
                ApplicationType = c.ApplicationType
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = new ProductViewModel
            {
                CategoryDropDown = _productService.GetCategoryList(),
                AppTypeDropDown = _productService.GetAppTypeList(),
            };
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) {
                productViewModel.CategoryDropDown = _productService.GetCategoryList();
                productViewModel.AppTypeDropDown = _productService.GetAppTypeList();
                return RedirectToAction("Create");
            } 

           

            var files = HttpContext.Request.Form.Files;
            productViewModel.Image = _imageService.ImageLoad(files);


            var product = new Product
            {
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                Image = productViewModel.Image,
                CategoryId = productViewModel.CategoryId,
                ApplicationTypeId = productViewModel.ApplicationTypeId
                
            };
            _productRepository.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var entity = _productRepository.GetById(id);
            var product = new ProductViewModel
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                Image = _imageService.imgPath + entity.Image,
                CategoryDropDown = _productService.GetCategoryList(),
                AppTypeDropDown = _productService.GetAppTypeList()
            };
            return View(product);

        }



        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid) {
                return View(product);
            }

            var currentProduct = _productRepository.GetProductByid(product.Id);
            _imageService.DeleteImage(currentProduct.Image);

            var files = HttpContext.Request.Form.Files;

            var entity = new Product
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Image = _imageService.ImageLoad(files),
                CategoryId = product.CategoryId,
                ApplicationTypeId = product.ApplicationTypeId
            };

            _productRepository.Update(entity);

            return RedirectToAction("Index");
        }

        //    [HttpGet]
        //    public IActionResult Edit(int id)
        //    {
        //        var category = _categoryRepository.GetById(id);
        //        var model = new CategoryViewModel { Name = category.Name };

        //        return View(model);
        //    }

        //    [HttpPost]
        //    public IActionResult Edit(CategoryViewModel categoryViewModel)
        //    {
        //        if (!ModelState.IsValid) return View(categoryViewModel);

        //        var category = new Category { Name = categoryViewModel.Name, Id = categoryViewModel.Id };
        //        _categoryRepository.Update(category);

        //        return RedirectToAction("Index");
        //    }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductByid(id);

            var currentProduct = _productRepository.GetProductByid(product.Id);
            _imageService.DeleteImage(currentProduct.Image);


            _productRepository.Remove(product);

            return RedirectToAction("Index");
        }
        }
    }
