using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;

namespace InternetShop.Presistance.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
