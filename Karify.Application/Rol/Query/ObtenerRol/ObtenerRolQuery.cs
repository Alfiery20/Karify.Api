using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQuery : IRequest<IEnumerable<ObtenerRolQueryDTO>>
    {
        public string Nombre { get; set; }
    }
}
