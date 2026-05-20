using MediatR;

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
