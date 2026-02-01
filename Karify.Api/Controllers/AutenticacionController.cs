using Karify.Application.Autenticacion.Command.LoginGoogle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacionController : AbstractController
    {
        [HttpPost]
        [Route("iniciarSesion")]
        [ProducesResponseType(typeof(LoginCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> IniciarSesion(LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
