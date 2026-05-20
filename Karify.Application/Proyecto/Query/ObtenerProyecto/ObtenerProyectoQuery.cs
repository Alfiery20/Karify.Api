using MediatR;

namespace Karify.Application.Proyecto.Query.ObtenerProyecto
{
    public class ObtenerProyectoQuery : IRequest<IEnumerable<ObtenerProyectoQueryDTO>>
    {
        public string Nombre { get; set; }
        public int IdAlumno { get; set; }
    }
}
