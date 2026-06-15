using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;

namespace Karify.Application.Common.Interface
{
    public interface IGoogleService
    {
        Task<string> GoogleDecryptToken(LoginCommand command);
        Task EnvioSolicitudAprobacion(EnvioCorreoSolicitud envioCorreo);
        Task EnvioNotificacionAprobacion(AprobacionProyectoCorreo aprobacion);
        Task EnvioNotificacionRechazo(RechazoProyectoCorreo aprobacion);
    }
}
