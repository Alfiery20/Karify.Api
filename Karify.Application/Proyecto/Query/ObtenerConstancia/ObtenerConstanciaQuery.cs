using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Query.ObtenerConstancia
{
    public class ObtenerConstanciaQuery : IRequest<ObtenerConstanciaQueryDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
