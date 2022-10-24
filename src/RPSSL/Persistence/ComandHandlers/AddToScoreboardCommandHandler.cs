using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Application.UseCases.Scoreboard.Commands.AddToScoreboard;
using Domain.Entities;

namespace Persistence.ComandHandlers
{
    public class AddToScoreboardCommandHandler : IAddToScoreboardCommandHandler
    {
        private readonly IGameDbContext _context;
        private readonly IDateTime _dateTime;

        public AddToScoreboardCommandHandler(IGameDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<AddToScoreboardResponse> Handle(AddToScoreboardCommand request, CancellationToken cancellationToken)
        {
            var entity = new Scoreboard
            {
                FirstPlayerID = request.PlayerOneId,
                SecondPlayerID = request.PlayerTwoId,
                FirstPlayerChoiseID = request.PlayerOneChoiseId,
                SecondPlayerChoiseID = request.PlayerTwoChoiseId,
                GameResultID = request.Result,
                CreatedAt = _dateTime.Now
            };
            _context.Scoreboards.Add(entity);
            var id = await _context.SaveChangesAsync(cancellationToken);

            return new AddToScoreboardResponse 
            {
                Id = id,
            };
        }
    }

}
