using Application.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RPSSL.Extensions
{
    public static class PresentationDependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExternalRandomNumberConfigurations>(configuration.GetSection("ExternalRandomNumberConfigurations"));

            return services;
        }
    }
}
