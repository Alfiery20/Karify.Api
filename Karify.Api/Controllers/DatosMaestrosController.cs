using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DatosMaestrosController : AbstractController
    {
        [HttpGet]
        [Route("obtenerFacultad")]
        [ProducesResponseType(typeof(ObtenerFacultadQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerFacultad()
        {
            var response = await Mediator.Send(new ObtenerFacultadQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerEscuela/{idFacultad}")]
        [ProducesResponseType(typeof(ObtenerEscuelaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerFacultad(int idFacultad)
        {
            var response = await Mediator.Send(new ObtenerEscuelaQuery()
            {
                IdFacultad = idFacultad
            });
            return Ok(response);
        }
    }
}
