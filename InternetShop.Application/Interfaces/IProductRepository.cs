using InternetShop.Domain.Entites;

namespace InternetShop.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductByid(int id);
    }
}
