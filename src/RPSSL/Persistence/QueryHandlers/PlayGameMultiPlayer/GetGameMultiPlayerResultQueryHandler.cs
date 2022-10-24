using Application.Common.Interfaces;
using Application.UseCases.GameResults.Queries.GetPossibleGameResults;
using System;
using System.Threading.Tasks;
using System.Threading;
using Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries;
using System.Linq;

namespace Persistence.QueryHandlers.PlayGameMultiPlayer
{
    public class GetGameMultiPlayerResultQueryHandler : IGetGameMultiPlayerResultQueryHandler
    {
        private readonly ICalculateGameResult _calculateGameResult;
        private readonly IGetPossibleGameResultsQueryHandler _getPossibleGameResultsQueryHandler;

        public GetGameMultiPlayerResultQueryHandler(
            ICalculateGameResult calculateGameResult,
            IGetPossibleGameResultsQueryHandler getPossibleGameResultsQueryHandler)
        {
            _calculateGameResult = calculateGameResult;
            _getPossibleGameResultsQueryHandler = getPossibleGameResultsQueryHandler;
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

            //TODO: add connection to scoreboard.

            return result;
        }
    }

}
