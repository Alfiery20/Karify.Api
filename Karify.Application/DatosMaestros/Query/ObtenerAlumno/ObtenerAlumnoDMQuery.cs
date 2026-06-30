using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerAlumno
{
    public class ObtenerAlumnoDMQuery : IRequest<IEnumerable<ObtenerAlumnoDMQueryDTO>>
    {
        public string Nombre { get; set; }
    }
}
