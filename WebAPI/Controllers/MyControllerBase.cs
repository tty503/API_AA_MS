using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyControllerBase : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator? mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}