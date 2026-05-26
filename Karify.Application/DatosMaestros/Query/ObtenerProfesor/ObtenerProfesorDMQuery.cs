using MediatR;

namespace Karify.Application.DatosMaestros.Query.ObtenerProfesor
{
    public class ObtenerProfesorDMQuery : IRequest<IEnumerable<ObtenerProfesorQueryDMDTO>>
    {
        public string Nombre { get; set; }
    }
}
