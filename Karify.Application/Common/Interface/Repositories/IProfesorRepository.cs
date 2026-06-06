using Karify.Application.Profesor.Command.AgregarProfesor;
using Karify.Application.Profesor.Command.EditarProfesor;
using Karify.Application.Profesor.Command.EliminarProfesor;
using Karify.Application.Profesor.Query.ObtenerProfesor;
using Karify.Application.Profesor.Query.VerProfesor;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IProfesorRepository
    {
        Task<AgregarProfesorCommandDTO> AgregarProfesor(AgregarProfesorCommand command);
        Task<EditarProfesorCommandDTO> EditarProfesor(EditarProfesorCommand command);
        Task<IEnumerable<ObtenerProfesorQueryDTO>> ObtenerProfesor(ObtenerProfesorQuery query);
        Task<EliminarProfesorCommandDTO> EliminarProfesor(EliminarProfesorCommand command);
        Task<VerProfesorQueryDTO> VerProfesor(VerProfesorQuery query);
        Task<string> ObtenerCorreoProfesor(int idProfesor);
    }
}
