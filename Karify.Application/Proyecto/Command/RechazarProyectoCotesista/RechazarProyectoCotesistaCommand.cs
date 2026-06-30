using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.RechazarProyectoCotesista
{
    public class RechazarProyectoCotesistaCommand : IRequest<RechazarProyectoCotesistaCommandDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
