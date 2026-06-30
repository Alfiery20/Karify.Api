using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AprobarProyectoCotesista
{
    public class AprobarProyectoCotesistaCommand : IRequest<AprobarProyectoCotesistaCommandDTO>
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
    }
}
