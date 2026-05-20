using MediatR;

namespace Karify.Application.Rol.Command.EliminarRol
{
    public class EliminarRolCommand : IRequest<EliminarRolCommandDTO>
    {
        public int IdRol { get; set; }
    }
}
