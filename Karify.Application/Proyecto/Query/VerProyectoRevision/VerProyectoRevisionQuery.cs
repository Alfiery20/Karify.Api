using MediatR;

namespace Karify.Application.Proyecto.Query.VerProyectoRevision
{
    public class VerProyectoRevisionQuery : IRequest<VerProyectoRevisionQueryDTO>
    {
        public int IdProyecto { get; set; }
    }
}
