using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;
using InternetShop.Presistance.Repository;
using InternetShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationType _appTypeRepository;

        public ApplicationTypeController(IApplicationType appTypeRepository)
        {
            _appTypeRepository = appTypeRepository;
        }

        public IActionResult Index()
        {
            var appTypes = _appTypeRepository.GetAll();
            var model = appTypes.Select(c => new AppTypeViewModel
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
        public IActionResult Create(AppTypeViewModel appTypeViewModel)
        {
            if (!ModelState.IsValid) return View();

            var appType = new ApplicationType
            {
                Name = appTypeViewModel.Name,
            };
            _appTypeRepository.Add(appType);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appType = _appTypeRepository.GetById(id);
            var model = new AppTypeViewModel { Name = appType.Name };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AppTypeViewModel appTypeViewModel)
        {
            if (!ModelState.IsValid) return View(appTypeViewModel);

            var appType = new ApplicationType { Name = appTypeViewModel.Name, Id = appTypeViewModel.Id };
            _appTypeRepository.Update(appType);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _appTypeRepository.GetById(id);

            _appTypeRepository.Remove(category);

            return RedirectToAction("Index");
        }
    }

}
