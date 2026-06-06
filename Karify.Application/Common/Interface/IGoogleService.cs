using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Proyecto.Command.AgregarProyecto;

namespace Karify.Application.Common.Interface
{
    public interface IGoogleService
    {
        Task<string> GoogleDecryptToken(LoginCommand command);
        Task EnvioCorreo(EnvioCorreoSolicitud envioCorreo);
    }
}
