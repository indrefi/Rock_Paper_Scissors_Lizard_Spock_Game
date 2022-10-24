using MediatR;

namespace Application.UseCases.Scoreboard.Commands.AddToScoreboard
{
    public class AddToScoreboardCommand : IRequest<AddToScoreboardResponse>
    {
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int PlayerOneChoiseId { get; set; }
        public int PlayerTwoChoiseId { get; set; }
        public int Result { get; set; }
    }
}