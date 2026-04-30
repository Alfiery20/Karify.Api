using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.EditarProyecto
{
    public class EditarProyectoCommandHandler : IRequestHandler<EditarProyectoCommand, EditarProyectoCommandDTO>
    {
        public Task<EditarProyectoCommandDTO> Handle(EditarProyectoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
