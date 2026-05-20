using MediatR;

namespace Karify.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQuery : IRequest<IEnumerable<ObtenerRolQueryDTO>>
    {
        public string Nombre { get; set; }
    }
}
