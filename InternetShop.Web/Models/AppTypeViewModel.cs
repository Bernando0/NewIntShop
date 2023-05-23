using System.ComponentModel.DataAnnotations;

namespace InternetShop.Web.Models
{
    public class AppTypeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;
    }
}
