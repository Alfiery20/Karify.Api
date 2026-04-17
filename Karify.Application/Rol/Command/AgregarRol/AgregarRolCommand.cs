using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Command.AgregarRol
{
    public class AgregarRolCommand : IRequest<AgregarRolCommandDTO>
    {
        public string Nombre { get; set; }
    }
}
