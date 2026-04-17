using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Command.EditarRol
{
    public class EditarRolCommand : IRequest<EditarRolCommandDTO>
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }
}
