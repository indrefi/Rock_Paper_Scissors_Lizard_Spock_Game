using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using System.Collections.Generic;

namespace RPSSL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoisesController : ApiControllerBase
    {
        private readonly ILogger<ChoisesController> _logger;

        public ChoisesController(ILogger<ChoisesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all tooltips.
        /// </summary>
        /// <returns>return as TooltipsListViewModel.</returns>
        [HttpGet()]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AvailableChoisesDto>>> Get() => 
            await Mediator.Send(new GetAvailableChoisesQuery());
    }
}
