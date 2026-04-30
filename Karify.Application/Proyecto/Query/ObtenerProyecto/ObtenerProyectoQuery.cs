using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Query.ObtenerProyecto
{
    public class ObtenerProyectoQuery : IRequest<IEnumerable<ObtenerProyectoQueryDTO>>
    {
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
    }
}
