using KR.Hanyang.Mindwatch.Domain.MlService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Infrastructure.MlService
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddMlServices(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["MlService:BaseUrl"] ?? "";

            // Register Services
            services.AddHttpClient<IMlService, MlService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }
    }
}
