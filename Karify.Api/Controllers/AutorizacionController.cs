using Karify.Api.Filter;
using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class AutorizacionController : AbstractController
    {
        [HttpGet]
        [Route("informacionPersonal")]
        [ProducesResponseType(typeof(ObtenerInformacionUsuarioQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> InformacionPersonal()
        {
            var response = await Mediator.Send(new ObtenerInformacionUsuarioQuery()
            {
                IdUsuario = Convert.ToInt32(this.CurrentUser.Id)
            });
            return Ok(response);
        }
    }
}
