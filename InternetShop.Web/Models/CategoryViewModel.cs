using System.ComponentModel.DataAnnotations;

namespace InternetShop.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field must be filled")]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;
    }
}
