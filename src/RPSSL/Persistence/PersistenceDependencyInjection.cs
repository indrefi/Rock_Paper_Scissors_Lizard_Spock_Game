using Application.Common.Interfaces;
using Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries;
using Application.UseCases.AvailableChoises.Queries.GetARandomChoise;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using Application.UseCases.GameResults.Queries.GetPossibleGameResults;
using Application.UseCases.PlayGameSinglePlayer.Queries;
using Application.UseCases.Scoreboard.Commands.AddToScoreboard;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ComandHandlers;
using Persistence.QueryHandlers.AvailableChoises;
using Persistence.QueryHandlers.GameResults;
using Persistence.QueryHandlers.PlayGameMultiPlayer;
using Persistence.QueryHandlers.PlayGameSinglePlayer;

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
            // Choises
            services.AddTransient<IGetARandomChoiseQueryHandler, GetARandomChoiseQueryHandler>();
            services.AddTransient<IGetAvailableChoisesQueryHandler, GetAvailableChoisesQueryHandler>();

            // Game Results            
            services.AddTransient<IGetPossibleGameResultsQueryHandler, GetPossibleGameResultsQueryHandler>();

            // Play Single Player
            services.AddTransient<IGetGameSinglePlayerResultQueryHandler, GetGameSinglePlayerResultQueryHandler>();
            services.AddTransient<IGetGameMultiPlayerResultQueryHandler, GetGameMultiPlayerResultQueryHandler>();

            //Scoreboards
            services.AddTransient<IAddToScoreboardCommandHandler, AddToScoreboardCommandHandler>();


        }

        private static void AddMediatRDependencies(this IServiceCollection services)
        {
            // Choises
            services.AddMediatR(typeof(IGetARandomChoiseQueryHandler), typeof(GetARandomChoiseQueryHandler));
            services.AddMediatR(typeof(IGetAvailableChoisesQueryHandler), typeof(GetAvailableChoisesQueryHandler));

            // Game Results            
            services.AddMediatR(typeof(IGetPossibleGameResultsQueryHandler), typeof(GetPossibleGameResultsQueryHandler));

            // Play Single Player
            services.AddMediatR(typeof(IGetGameSinglePlayerResultQueryHandler), typeof(GetGameSinglePlayerResultQueryHandler));
            services.AddMediatR(typeof(IGetGameMultiPlayerResultQueryHandler), typeof(GetGameMultiPlayerResultQueryHandler));

            // Scoreboard
            services.AddMediatR(typeof(IAddToScoreboardCommandHandler), typeof(AddToScoreboardCommandHandler));

        }
    }
}
