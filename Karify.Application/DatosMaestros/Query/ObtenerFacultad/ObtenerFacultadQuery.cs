using MediatR;

namespace Karify.Application.DatosMaestros.Query.ObtenerFacultad
{
    public class ObtenerFacultadQuery : IRequest<IEnumerable<ObtenerFacultadQueryDTO>>
    {
    }
}
