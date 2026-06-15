using MediatR;

namespace Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor
{
    public class ObtenerProyectoPorProfesorQuery : IRequest<IEnumerable<ObtenerProyectoPorProfesorQueryDTO>>
    {
        public int IdProfesor { get; set; }
    }
}
