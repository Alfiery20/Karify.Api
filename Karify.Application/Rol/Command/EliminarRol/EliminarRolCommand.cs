using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Command.EliminarRol
{
    public class EliminarRolCommand : IRequest<EliminarRolCommandDTO>
    {
        public int IdRol { get; set; }
    }
}
