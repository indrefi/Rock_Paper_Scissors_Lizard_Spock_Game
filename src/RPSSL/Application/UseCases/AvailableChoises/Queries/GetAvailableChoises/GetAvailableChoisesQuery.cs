using MediatR;
using System.Collections.Generic;

namespace Application.UseCases.AvailableChoises.Queries.GetAvailableChoises
{
    public class GetAvailableChoisesQuery : IRequest<List<AvailableChoisesDto>>
    {
    }
}