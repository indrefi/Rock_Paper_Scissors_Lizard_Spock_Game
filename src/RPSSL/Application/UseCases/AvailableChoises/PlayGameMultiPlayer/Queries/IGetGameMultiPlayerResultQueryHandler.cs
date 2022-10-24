using MediatR;

namespace Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries
{
    public interface IGetGameMultiPlayerResultQueryHandler : IRequestHandler<GetGameMultiPlayerResultQuery, GameMultiPlayerResultDto>
    {
    }
}
