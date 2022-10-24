using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Application.UseCases.AvailableChoises.Queries.GetARandomChoise;

namespace RPSSL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoisesController : ApiControllerBase
    {
        private readonly ILogger<ChoisesController> _logger;

        public ChoisesController(ILogger<ChoisesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all choises.
        /// </summary>
        /// <returns>return a list of AvailableChoisesDto.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AvailableChoisesDto>>> GetAllChoises() => 
            await Mediator.Send(new GetAvailableChoisesQuery());

        /// <summary>
        /// Gets a random choise.
        /// </summary>
        /// <returns>return as AvailableChoisesDto.</returns>
        [HttpGet("/choise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AvailableChoisesDto>> GetRandomChoise() =>
            await Mediator.Send(new GetARandomChoiseQuery());
    }
}
