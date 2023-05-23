using InternetShop.Application.Interfaces;

namespace InternetShop.Presistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> result = _context.Set<T>();
            return result;
        }

        public T GetById(int id)
        {
            T result = _context.Set<T>().Find(id);
            return result;
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
    }
}
