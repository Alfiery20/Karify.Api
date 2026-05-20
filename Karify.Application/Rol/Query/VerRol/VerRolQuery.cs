using MediatR;

namespace Karify.Application.Rol.Query.VerRol
{
    public class VerRolQuery : IRequest<VerRolQueryDTO>
    {
        public int IdRol { get; set; }
    }
}
