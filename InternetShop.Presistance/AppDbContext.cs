using InternetShop.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Presistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
    }
}
