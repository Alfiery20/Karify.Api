using Karify.Api.Filter;
using Karify.Application.Usuario.Command.ActualizarInformacion;
using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class UsuarioController : AbstractController
    {
        [HttpPost]
        [Route("actualizarInformacion")]
        [ProducesResponseType(typeof(ActualizarInformacionCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ActualizarInformacionPersonal(ActualizarInformacionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
