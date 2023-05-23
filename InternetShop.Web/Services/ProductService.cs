using InternetShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetShop.Web.Services
{
    public class ProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IApplicationType _appTypeRepository;

        public ProductService(ICategoryRepository categoryRepository, IApplicationType applicationType)
        {
            _categoryRepository = categoryRepository;
            _appTypeRepository = applicationType;
        }
        public List<SelectListItem> GetCategoryList() {
            var categories = _categoryRepository.GetAll();

            var dropdown = categories.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return dropdown;
        }


        public List<SelectListItem> GetAppTypeList() {
            var apps = _appTypeRepository.GetAll();

            var dropdown = apps.Select(x=> new SelectListItem{
            Value = x.Id.ToString(),
                    Text = x.Name
            }).ToList();
            return dropdown;
        
        }
    }
}
