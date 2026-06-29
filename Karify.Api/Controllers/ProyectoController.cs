using Karify.Api.Filter;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.CancelarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using Karify.Application.Proyecto.Query.ObtenerConstancia;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor;
using Karify.Application.Proyecto.Query.VerProyecto;
using Karify.Application.Proyecto.Query.VerProyectoRevision;
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
            query.IdAlumno = Convert.ToInt32(this.CurrentUser.Id);
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
            command.IdAlumno = Convert.ToInt32(this.CurrentUser.Id);
            command.NombreAlumno = this.CurrentUser.NombreCompleto;
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

        [HttpGet]
        [Route("obtenerProyectoPorProfesor")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerProyectoPorProfesorQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerProyectoPorProfesor()
        {
            var response = await Mediator.Send(new ObtenerProyectoPorProfesorQuery()
            {
                IdProfesor = Convert.ToInt32(this.CurrentUser.Id)
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("verProyectoRevision/{idProyecto}")]
        [ProducesResponseType(typeof(VerProyectoRevisionQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> VerProyectoRevision(int idProyecto)
        {
            var response = await Mediator.Send(new VerProyectoRevisionQuery { IdProyecto = idProyecto });
            return Ok(response);
        }

        [HttpPost]
        [Route("AprobarProyecto/{idProyecto}")]
        [ProducesResponseType(typeof(AprobarProyectoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AprobarProyecto(int idProyecto)
        {
            var command = new AprobarProyectoCommand
            {
                IdProyecto = idProyecto,
                IdUsuario = Convert.ToInt32(this.CurrentUser.Id)
            };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("RechazarProyecto/{idProyecto}")]
        [ProducesResponseType(typeof(RechazarProyectoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> RechazarProyecto(int idProyecto)
        {
            var command = new RechazarProyectoCommand
            {
                IdProyecto = idProyecto,
                IdUsuario = Convert.ToInt32(this.CurrentUser.Id)
            };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("CancelarProyecto/{idProyecto}")]
        [ProducesResponseType(typeof(CancelarProyectoCommandDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelarProyecto(int idProyecto)
        {
            var command = new CancelarProyectoCommand
            {
                IdProyecto = idProyecto,
                IdUsuario = Convert.ToInt32(this.CurrentUser.Id)
            };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("descargarConstancia/{idProyecto}")]
        [ProducesResponseType(typeof(ObtenerConstanciaQueryDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> DescargarConstancia(int idProyecto)
        {
            var command = new ObtenerConstanciaQuery
            {
                IdProyecto = idProyecto,
                IdUsuario = Convert.ToInt32(this.CurrentUser.Id)
            };
            var response = await Mediator.Send(command);

            if (response is null || string.IsNullOrEmpty(response.Base64))
                return NotFound("No se encontró la constancia para este proyecto.");

            var pdfBytes = Convert.FromBase64String(response.Base64);

            return File(pdfBytes, "application/pdf", response.NombreConstancia);
        }
    }
}
