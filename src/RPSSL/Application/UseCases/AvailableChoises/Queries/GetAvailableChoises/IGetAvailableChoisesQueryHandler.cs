using MediatR;
using System.Collections.Generic;

namespace Application.UseCases.AvailableChoises.Queries.GetAvailableChoises
{
    public interface IGetAvailableChoisesQueryHandler : IRequestHandler<GetAvailableChoisesQuery, List<AvailableChoisesDto>>
    {
    }
}