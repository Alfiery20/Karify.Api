using Karify.Application.DatosMaestros.Query.ObtenerAlumno;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using Karify.Application.DatosMaestros.Query.ObtenerProfesor;
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
        [ProducesResponseType(typeof(IEnumerable<ObtenerFacultadQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerFacultad()
        {
            var response = await Mediator.Send(new ObtenerFacultadQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerEscuela/{idFacultad}")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerEscuelaQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerFacultad(int idFacultad)
        {
            var response = await Mediator.Send(new ObtenerEscuelaQuery()
            {
                IdFacultad = idFacultad
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerProfesor/{nombre?}")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerProfesorQueryDMDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerProfesor(string? nombre)
        {
            var response = await Mediator.Send(new ObtenerProfesorDMQuery()
            {
                Nombre = nombre ?? ""
            });
            return Ok(response);
        }

        [HttpGet]
        [Route("obtenerAlumno/{nombre?}")]
        [ProducesResponseType(typeof(IEnumerable<ObtenerAlumnoDMQueryDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerAlumnoCotesista(string? nombre)
        {
            var response = await Mediator.Send(new ObtenerAlumnoDMQuery()
            {
                Nombre = nombre ?? ""
            });
            return Ok(response);
        }
    }
}
