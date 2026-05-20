using MediatR;

namespace Karify.Application.Usuario.Query.ObtenerInformacionUsuario
{
    public class ObtenerInformacionUsuarioQuery : IRequest<ObtenerInformacionUsuarioQueryDTO>
    {
        public int IdUsuario { get; set; }
    }
}
