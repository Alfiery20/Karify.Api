using Karify.Application.Rol.Command.AgregarRol;
using MediatR;

namespace Karify.Application.Rol.Command.EditarRol
{
    public class EditarRolCommand : IRequest<EditarRolCommandDTO>
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public AsignarPermiso[] Permisos { get; set; }
    }
}
