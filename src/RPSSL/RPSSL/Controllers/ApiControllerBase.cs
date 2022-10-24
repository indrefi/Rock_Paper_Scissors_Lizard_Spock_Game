using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace RPSSL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        #region Fields

        #region PRIVATE

        private IMediator _mediator;

        #endregion

        #region PROTECTED

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        #endregion

        #endregion
    }
}
