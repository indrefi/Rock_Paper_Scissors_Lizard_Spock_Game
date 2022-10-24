using MediatR;

namespace Application.UseCases.Scoreboard.Commands.AddToScoreboard
{
    public interface IAddToScoreboardCommandHandler : IRequestHandler<AddToScoreboardCommand, AddToScoreboardResponse>
    {
    }
}