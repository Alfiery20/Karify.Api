using MediatR;

namespace Karify.Application.DatosMaestros.Query.ObtenerEscuela
{
    public class ObtenerEscuelaQuery : IRequest<IEnumerable<ObtenerEscuelaQueryDTO>>
    {
        public int IdFacultad { get; set; }
    }
}
