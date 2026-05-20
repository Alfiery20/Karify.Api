using MediatR;

namespace Karify.Application.Profesor.Command.EliminarProfesor
{
    public class EliminarProfesorCommand : IRequest<EliminarProfesorCommandDTO>
    {
        public int IdProfesor { get; set; }
    }
}
