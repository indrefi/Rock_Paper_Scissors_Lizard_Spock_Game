using MediatR;

namespace Application.UseCases.PlayGameSinglePlayer.Queries
{
    public class GetGameSinglePlayerResultQuery : IRequest<GameSinglePlayerResultDto>
    {
        public int Player { get; set; }
    }
}
