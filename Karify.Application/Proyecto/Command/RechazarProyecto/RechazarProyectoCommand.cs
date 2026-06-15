using MediatR;

namespace Karify.Application.Proyecto.Command.RechazarProyecto
{
    public class RechazarProyectoCommand : IRequest<RechazarProyectoCommandDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
