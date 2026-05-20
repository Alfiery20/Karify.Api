using MediatR;

namespace Karify.Application.Rol.Command.AgregarRol
{
    public class AgregarRolCommand : IRequest<AgregarRolCommandDTO>
    {
        public string Nombre { get; set; }
        public AsignarPermiso[] Permisos { get; set; }
    }

    public class AsignarPermiso
    {
        public int IdRuta { get; set; }
    }
}
