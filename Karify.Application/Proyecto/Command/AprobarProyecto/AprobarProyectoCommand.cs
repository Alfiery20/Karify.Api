using MediatR;

namespace Karify.Application.Proyecto.Command.AprobarProyecto
{
    public class AprobarProyectoCommand : IRequest<AprobarProyectoCommandDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
