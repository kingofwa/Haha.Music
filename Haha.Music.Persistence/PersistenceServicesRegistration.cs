using Haha.Music.Application.Contracts.Persistence;
using Haha.Music.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Haha.Music.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HahaMusicDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("HahaMusicConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            return services;
        }
    }
}
