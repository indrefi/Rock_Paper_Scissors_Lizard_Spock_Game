using MediatR;
using System.Collections.Generic;

namespace Application.UseCases.GameResults.Queries.GetPossibleGameResults
{
    public interface IGetPossibleGameResultsQueryHandler : IRequestHandler<GetPossibleGameResultsQuery, List<GameResultDto>>
    {
    }
}