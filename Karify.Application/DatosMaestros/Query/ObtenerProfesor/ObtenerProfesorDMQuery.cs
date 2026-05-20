using MediatR;

namespace Karify.Application.DatosMaestros.Query.ObtenerProfesor
{
    public class ObtenerProfesorDMQuery : IRequest<IEnumerable<ObtenerProfesorQueryDMDTO>>
    {
        public int IdEscuela { get; set; }
        public string Nombre { get; set; }
    }
}
