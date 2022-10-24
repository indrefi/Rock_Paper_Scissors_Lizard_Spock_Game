using Application.Common.Interfaces;
using Application.UseCases.GameResults.Queries.GetPossibleGameResults;
using System;
using System.Threading.Tasks;
using System.Threading;
using Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries;
using System.Linq;
using Application.UseCases.Scoreboard.Commands.AddToScoreboard;
using Microsoft.EntityFrameworkCore;
using Application.Common.Constants;

namespace Persistence.QueryHandlers.PlayGameMultiPlayer
{
    public class GetGameMultiPlayerResultQueryHandler : IGetGameMultiPlayerResultQueryHandler
    {
        private readonly ICalculateGameResult _calculateGameResult;
        private readonly IGetPossibleGameResultsQueryHandler _getPossibleGameResultsQueryHandler;
        private readonly IAddToScoreboardCommandHandler _addToScoreboardCommandHandler;
        private readonly IGameDbContext _context;

        public GetGameMultiPlayerResultQueryHandler(
            IGameDbContext context,
            ICalculateGameResult calculateGameResult,
            IGetPossibleGameResultsQueryHandler getPossibleGameResultsQueryHandler,
            IAddToScoreboardCommandHandler addToScoreboardCommandHandler)
        {
            _context = context;
            _calculateGameResult = calculateGameResult;
            _getPossibleGameResultsQueryHandler = getPossibleGameResultsQueryHandler;
            _addToScoreboardCommandHandler = addToScoreboardCommandHandler;
        }

        public async Task<GameMultiPlayerResultDto> Handle(GetGameMultiPlayerResultQuery request, CancellationToken cancellationToken)
        {
            var result = new GameMultiPlayerResultDto();

            var possibleGameResults = await _getPossibleGameResultsQueryHandler.Handle(new GetPossibleGameResultsQuery(), cancellationToken);
            var computedGameResultId = _calculateGameResult.CalculateResult(request.PlayerOne, request.PlayerTwo);

            if (computedGameResultId < 0)
            {
                throw new Exception("Unable to calculate the game result.");
            }

            var computedGameResultDto = possibleGameResults.Single(x => x.Id == computedGameResultId);

            result = new GameMultiPlayerResultDto
            {
                PlayerOne = request.PlayerOne,
                PlayerTwo = request.PlayerTwo,
                Results = computedGameResultDto.Name
            };

            var playerOne = await _context.Players.SingleAsync(x => x.Name == PlayerConstants.PlayerOneName, cancellationToken);
            var playerTwo = await _context.Players.SingleAsync(x => x.Name == PlayerConstants.PlayerTwoName, cancellationToken);

            await _addToScoreboardCommandHandler.Handle(
                new AddToScoreboardCommand 
                {
                    PlayerOneId = playerOne.Id,
                    PlayerTwoId = playerTwo.Id,
                    PlayerOneChoiseId = request.PlayerOne,
                    PlayerTwoChoiseId = request.PlayerTwo,
                    Result = computedGameResultDto.Id
                },
                cancellationToken);

            return result;
        }
    }

}
