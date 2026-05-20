using Karify.Application.Usuario.Command.ActualizarInformacion;
using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ObtenerInformacionUsuarioQueryDTO> ObtenerInformacionPersonal(ObtenerInformacionUsuarioQuery query);
        Task<ActualizarInformacionCommandDTO> ActualizarInformacionPersonal(ActualizarInformacionCommand command);
    }
}
