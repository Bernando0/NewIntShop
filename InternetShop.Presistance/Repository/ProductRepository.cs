

using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Presistance.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public Product GetProductByid(int id)
        {
            var product = _appDbContext.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _appDbContext.Products.Include(products => products.Category).Include(p => p.ApplicationType);
            return products;
        }
    }
}
