using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.CancelarProyecto
{
    public class CancelarProyectoCommand : IRequest<CancelarProyectoCommandDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
