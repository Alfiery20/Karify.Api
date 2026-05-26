using Karify.Api.Controllers;
using Karify.Api.Filter;
using Karify.Application.Profesor.Command.AgregarProfesor;
using Karify.Application.Profesor.Command.EditarProfesor;
using Karify.Application.Profesor.Command.EliminarProfesor;
using Karify.Application.Profesor.Query.ObtenerProfesor;
using Karify.Application.Profesor.Query.VerProfesor;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.ContProfesorlers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class ProfesorController : AbstractController
    {
        [HttpPost]
        [Route("obtenerProfesor")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerProfesorQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerProfesor(ObtenerProfesorQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verProfesor/{idProfesor}")]
        [ProducesResponseType(typeof(VerProfesorQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerProfesor(int idProfesor)
        {
            var response = await Mediator.Send(new VerProfesorQuery { IdProfesor = idProfesor });
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarProfesor")]
        [ProducesResponseType(typeof(AgregarProfesorCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarProfesor(AgregarProfesorCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("editarProfesor")]
        [ProducesResponseType(typeof(EditarProfesorCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarProfesor(EditarProfesorCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminarProfesor/{idProfesor}")]
        [ProducesResponseType(typeof(EliminarProfesorCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EliminarProfesor(int idProfesor)
        {
            var response = await Mediator.Send(new EliminarProfesorCommand() { IdProfesor = idProfesor });
            return Ok(response);
        }
    }
}
