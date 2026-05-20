using Karify.Api.Filter;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.VerProyecto;
using Microsoft.AspNetCore.Mvc;

namespace Karify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class ProyectoController : AbstractController
    {
        [HttpPost]
        [Route("obtenerProyecto")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerProyectoQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerProyecto(ObtenerProyectoQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("verProyecto/{idProyecto}")]
        [ProducesResponseType(typeof(VerProyectoQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerProyecto(int idProyecto)
        {
            var response = await Mediator.Send(new VerProyectoQuery { IdProyecto = idProyecto });
            return Ok(response);
        }

        [HttpPost]
        [Route("agregarProyecto")]
        [ProducesResponseType(typeof(AgregarProyectoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgregarProyecto(AgregarProyectoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Route("editarProyecto")]
        [ProducesResponseType(typeof(EditarProyectoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarProyecto(EditarProyectoCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
