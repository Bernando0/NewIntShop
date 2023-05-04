using System.ComponentModel.DataAnnotations;

namespace InternetShop.Domain.Entites
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
