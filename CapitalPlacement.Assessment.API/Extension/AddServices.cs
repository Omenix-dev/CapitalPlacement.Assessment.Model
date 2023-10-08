using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.DataAccess.Utility;
using SpredMedia.Catalogue.Infrastructure.Repository;

namespace CapitalPlacement.Assessment.API.Extension
{
    public static class AddServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // adding the instances for all the services to be registered here
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Profiler));
        }
    }
}
