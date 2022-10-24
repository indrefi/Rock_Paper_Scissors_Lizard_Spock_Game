using Application.Common.Interfaces;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.QueryHandlers.AvailableChoises;

namespace Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDBContext(configuration);
            services.AddHandlers();
            services.AddMediatRDependencies();

            return services;
        }

        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GameDatabase"));
            });
            services.AddScoped<IGameDbContext>(provider => provider.GetRequiredService<GameDbContext>());           

            return services;
        }

        private static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IGetAvailableChoisesQueryHandler, GetAvailableChoisesQueryHandler>();
        }

        private static void AddMediatRDependencies(this IServiceCollection services)
        {
            // Available Choises

            services.AddMediatR(typeof(IGetAvailableChoisesQueryHandler), typeof(GetAvailableChoisesQueryHandler));
        }
    }
}
