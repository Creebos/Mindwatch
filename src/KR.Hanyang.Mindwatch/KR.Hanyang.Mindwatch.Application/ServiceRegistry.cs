using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Application.Services;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KR.Hanyang.Mindwatch.Application
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
