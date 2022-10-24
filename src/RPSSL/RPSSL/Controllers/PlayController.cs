using Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries;
using Application.UseCases.PlayGameSinglePlayer.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RPSSL.Controllers
{
    [ApiController]
    [Route("play")]
    public class PlayController : ApiControllerBase
    {
        private readonly ILogger<PlayController> _logger;

        public PlayController(ILogger<PlayController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Play against computer.
        /// </summary>
        /// <returns>return the result of playing against the computer.</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GameSinglePlayerResultDto>> PlaySinglePlayer(GameSinglePlayerRequest request) =>
            await Mediator.Send(new GetGameSinglePlayerResultQuery { Player = request.Player });

        [HttpPut("/multi")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GameMultiPlayerResultDto>> PlayMultiPlayer(GameMultiPlayerRequest request) =>
            await Mediator.Send(new GetGameMultiPlayerResultQuery { PlayerOne = request.PlayerOne,PlayerTwo = request.PlayerTwo });

    }
}
