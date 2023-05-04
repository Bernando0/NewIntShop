using InternetShop.Application.Interfaces;
using InternetShop.Domain.Entites;

namespace InternetShop.Presistance.Repository
{
    public class ApplicationTypeRepository : GenericRepository<ApplicationType>, IApplicationType
    {
        public ApplicationTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
