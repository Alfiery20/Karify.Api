using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyectoCotesista;
using Karify.Application.Proyecto.Command.CancelarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyectoCotesista;
using Karify.Application.Proyecto.Query.ObtenerConstancia;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor;
using Karify.Application.Proyecto.Query.VerProyecto;
using Karify.Application.Proyecto.Query.VerProyectoRevision;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IProyectoRepository
    {
        Task<AgregarProyectoCommandDTO> AgregarProyecto(AgregarProyectoCommand command);
        Task<EditarProyectoCommandDTO> EditarProyecto(EditarProyectoCommand command);
        Task<IEnumerable<ObtenerProyectoQueryDTO>> ObtenerProyecto(ObtenerProyectoQuery query);
        Task<VerProyectoQueryDTO> VerProyecto(VerProyectoQuery query);
        Task<IEnumerable<ObtenerProyectoPorProfesorQueryDTO>> ObtenerProyectoPorProfesor(ObtenerProyectoPorProfesorQuery query);
        Task<VerProyectoRevisionQueryDTO> VerProyectoRevision(VerProyectoRevisionQuery query);
        Task<AprobarProyectoCommandDTO> AprobarProyecto(AprobarProyectoCommand command);
        Task<RechazarProyectoCommandDTO> RechazarProyecto(RechazarProyectoCommand command);
        Task<IEnumerable<AprobacionProyectoCorreo>> ObtenerInformacionAprobacion(int idProyecto);
        Task<IEnumerable<RechazoProyectoCorreo>> ObtenerInformacionRechazo(int idProyecto);
        Task<CancelarProyectoCommandDTO> CancelarProyecto(CancelarProyectoCommand command);
        Task<ObtenerConstanciaQueryDTO> ObtenerConstancia(ObtenerConstanciaQuery query);
        Task<AprobarProyectoCotesistaCommandDTO> AprobarProyectoCotesista(AprobarProyectoCotesistaCommand command);
        Task<RechazarProyectoCotesistaCommandDTO> RechazarProyectoCotesista(RechazarProyectoCotesistaCommand command);
        Task<string> ObtenerCorreoCotesista(int idProyecto);
        Task<EnvioCorreoProfesor> ObtenerInformacionCorreoProfesor(int idProyecto);
        Task<EnvioCorreoTesistaAceptacion> ObtenerInformacionCorreoCotesistaAprobacion(int idProyecto);
        Task<EnvioCorreoTesistaRechazo> ObtenerInformacionCorreoCotesistaRechazo(int idProyecto);
    }
}
