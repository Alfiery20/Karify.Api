using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.VerProyecto;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IProyectoRepository
    {
        Task<AgregarProyectoCommandDTO> AgregarProyecto(AgregarProyectoCommand command);
        Task<EditarProyectoCommandDTO> EditarProyecto(EditarProyectoCommand command);
        Task<IEnumerable<ObtenerProyectoQueryDTO>> ObtenerProyecto(ObtenerProyectoQuery query);
        Task<VerProyectoQueryDTO> VerProyecto(VerProyectoQuery query);
    }
}
