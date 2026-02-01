using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerFacultad
{
    public class ObtenerFacultadQuery : IRequest<IEnumerable<ObtenerFacultadQueryDTO>>
    {
    }
}
