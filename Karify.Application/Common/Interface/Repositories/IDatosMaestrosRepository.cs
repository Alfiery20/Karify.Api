using Karify.Application.DatosMaestros.Query.ObtenerAlumno;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using Karify.Application.DatosMaestros.Query.ObtenerProfesor;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IDatosMaestrosRepository
    {
        Task<IEnumerable<ObtenerFacultadQueryDTO>> ObtenerFacultad();
        Task<IEnumerable<ObtenerEscuelaQueryDTO>> ObtenerEscuela(ObtenerEscuelaQuery query);
        Task<IEnumerable<ObtenerProfesorQueryDMDTO>> ObtenerProfesorPorEscuela(ObtenerProfesorDMQuery query);
        Task<IEnumerable<ObtenerAlumnoDMQueryDTO>> ObtenerAlumnoCotesista(ObtenerAlumnoDMQuery query);
    }
}
