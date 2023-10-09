using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.DataAccess.Services;
using CapitalPlacement.Assessment.DataAccess.Utility;
using CapitalPlacement.Assessment.Model.Entities;
using SpredMedia.Catalogue.Infrastructure.Repository;

namespace CapitalPlacement.Assessment.API.Extension
{
    public static class AddServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // adding the instances for all the services to be registered here
            
            services.AddAutoMapper(typeof(Profiler));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProgramService, ProgramServices>();
            services.AddScoped<IWorkFlow, WorkFlowServices>();
        }
    }
}
