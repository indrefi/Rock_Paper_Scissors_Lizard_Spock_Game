using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using MediatR;

namespace Application.UseCases.AvailableChoises.Queries.GetARandomChoise
{
    public class GetARandomChoiseQuery : IRequest<AvailableChoisesDto>
    {
    }
}
