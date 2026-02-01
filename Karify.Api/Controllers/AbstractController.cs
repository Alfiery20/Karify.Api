using Karify.Api.Services;
using Karify.Application.Common.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Karify.Api.Controllers
{
    public class AbstractController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ICurrentUser CurrentUser => HttpContext.Session.GetString("dataUser") != null ? JsonConvert.DeserializeObject<CurrentUser>(HttpContext.Session.GetString("dataUser")) : null;
    }
}
