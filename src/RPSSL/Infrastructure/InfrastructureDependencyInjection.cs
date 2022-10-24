using Application.Common.Interfaces;
using Infrastructure.RandomNumber;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IGetRandomNumber, GetExternalRandomNumberService>();

            return services;
        }
    }
}
