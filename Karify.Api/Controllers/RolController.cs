using Karify.Api.Filter;
using Karify.Application.Rol.Command.AgregarRol;
using Karify.Application.Rol.Command.EditarRol;
using Karify.Application.Rol.Command.EliminarRol;
using Karify.Application.Rol.Query.ObtenerRol;
using Karify.Application.Rol.Query.VerRol;
using Karify.Application.Usuario.Command.ActualizarInformacion;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : AbstractController
    {
        [HttpGet]
        [Route("obtenerRol/{nombre?}")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerRolQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerRol(string? nombre = null)
        {
            var response = await Mediator.Send(new ObtenerRolQuery { Nombre = nombre });
            return Ok(response);
        }

        [HttpGet]
        [Route("verRol/{idRol}")]
        [ProducesResponseType(typeof(VerRolQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerRol(int idRol)
        {
            var response = await Mediator.Send(new VerRolQuery { IdRol = idRol });
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarRol")]
        [ProducesResponseType(typeof(AgregarRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarRol(AgregarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("editarRol")]
        [ProducesResponseType(typeof(EditarRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarRol(EditarRolCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarRol/{idRol}")]
        [ProducesResponseType(typeof(EliminarRolCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarRol(int idRol)
        {
            var response = await Mediator.Send(new EliminarRolCommand() { IdRol = idRol });
            return Ok(response);
        }
    }
}
