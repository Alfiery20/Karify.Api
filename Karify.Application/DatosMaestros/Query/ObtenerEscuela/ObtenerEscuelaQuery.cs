using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerEscuela
{
    public class ObtenerEscuelaQuery : IRequest<IEnumerable<ObtenerEscuelaQueryDTO>>
    {
        public int IdFacultad { get; set; }
    }
}
