﻿using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Application.UseCases.PlayGameSinglePlayer.Queries;
using Application.UseCases.AvailableChoises.Queries.GetARandomChoise;
using Application.UseCases.GameResults.Queries.GetPossibleGameResults;
using System.Linq;

namespace Persistence.QueryHandlers.PlayGameSinglePlayer
{
    public class GetGameSinglePlayerResultQueryHandler : IGetGameSinglePlayerResultQueryHandler
    {
        private readonly ICalculateGameResult _calculateGameResult;
        private readonly IGetARandomChoiseQueryHandler _getARandomChoiseQueryHandler;
        private readonly IGetPossibleGameResultsQueryHandler _getPossibleGameResultsQueryHandler;
        
        public GetGameSinglePlayerResultQueryHandler(
            ICalculateGameResult calculateGameResult,
            IGetARandomChoiseQueryHandler getARandomChoiseQueryHandler,
            IGetPossibleGameResultsQueryHandler getPossibleGameResultsQueryHandler)
        {
            _calculateGameResult = calculateGameResult;
            _getARandomChoiseQueryHandler = getARandomChoiseQueryHandler;
            _getPossibleGameResultsQueryHandler = getPossibleGameResultsQueryHandler;
        }

        public async Task<GameSinglePlayerResultDto> Handle(GetGameSinglePlayerResultQuery request, CancellationToken cancellationToken)
        {
            var result = new GameSinglePlayerResultDto();

            var possibleGameResults = await _getPossibleGameResultsQueryHandler.Handle(new GetPossibleGameResultsQuery(), cancellationToken);

            var computerChoise = await _getARandomChoiseQueryHandler.Handle(new GetARandomChoiseQuery(), cancellationToken);
            var computedGameResultId = _calculateGameResult.CalculateResult(request.Player, computerChoise.Id);
            
            if(computedGameResultId < 0)
            {
                throw new System.Exception("Unable to calculate the game result.");
            }

            var computedGameResultDto = possibleGameResults.Single(x => x.Id == computedGameResultId);

            result = new GameSinglePlayerResultDto
            {
                Player = request.Player,
                Computer = computerChoise.Id,
                Results = computedGameResultDto.Name
            };

            //TODO: add connection to scoreboard.

            return result;
        }
    }
}