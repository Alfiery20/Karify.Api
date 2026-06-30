using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyectoCotesista;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyectoCotesista;

namespace Karify.Application.Common.Interface
{
    public interface IGoogleService
    {
        Task<string> GoogleDecryptToken(LoginCommand command);
        Task EnvioSolicitudAprobacion(EnvioCorreoSolicitud envioCorreo);
        Task EnvioNotificacionAprobacion(AprobacionProyectoCorreo aprobacion);
        Task EnvioNotificacionRechazo(RechazoProyectoCorreo aprobacion);
        Task EnvioSolicitudAprobacionCotesista(EnvioCorreoSolicitudCotesista envioCorreo);
        Task EnvioNotificacionAprobacionCotesista(EnvioCorreoTesistaAceptacion aprobacion);
        Task EnvioNotificacionRechazoCotesista(EnvioCorreoTesistaRechazo aprobacion);
    }
}
