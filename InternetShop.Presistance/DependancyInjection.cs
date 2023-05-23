using InternetShop.Application.Interfaces;
using InternetShop.Presistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternetShop.Presistance
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IApplicationType, ApplicationTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
