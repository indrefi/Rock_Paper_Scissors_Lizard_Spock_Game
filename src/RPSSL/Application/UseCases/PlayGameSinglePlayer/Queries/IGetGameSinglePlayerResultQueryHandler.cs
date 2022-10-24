using MediatR;

namespace Application.UseCases.PlayGameSinglePlayer.Queries
{
    public interface IGetGameSinglePlayerResultQueryHandler : IRequestHandler<GetGameSinglePlayerResultQuery, GameSinglePlayerResultDto>
    {
    }
}
