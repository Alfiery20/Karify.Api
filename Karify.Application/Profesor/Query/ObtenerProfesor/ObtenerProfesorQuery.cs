using MediatR;

namespace Karify.Application.Profesor.Query.ObtenerProfesor
{
    public class ObtenerProfesorQuery : IRequest<IEnumerable<ObtenerProfesorQueryDTO>>
    {
        public string Nombre { get; set; }
        public int IdFacultad { get; set; }
        public int IdEscuela { get; set; }
    }
}
