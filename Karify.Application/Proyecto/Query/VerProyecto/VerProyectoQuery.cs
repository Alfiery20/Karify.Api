using MediatR;

namespace Karify.Application.Proyecto.Query.VerProyecto
{
    public class VerProyectoQuery : IRequest<VerProyectoQueryDTO>
    {
        public int IdProyecto { get; set; }
    }
}
