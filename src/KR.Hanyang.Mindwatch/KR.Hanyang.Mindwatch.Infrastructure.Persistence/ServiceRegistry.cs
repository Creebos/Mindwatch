using KR.Hanyang.Mindwatch.Domain.Interfaces;
using KR.Hanyang.Mindwatch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<MindwatchDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IMindwatchRepository, MindwatchRepository>();

            return services;
        }
    }
}
