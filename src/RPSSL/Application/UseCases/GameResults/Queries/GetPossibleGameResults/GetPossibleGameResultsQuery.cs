using MediatR;
using System.Collections.Generic;

namespace Application.UseCases.GameResults.Queries.GetPossibleGameResults
{
    public class GetPossibleGameResultsQuery : IRequest<List<GameResultDto>>
    {
    }
}
