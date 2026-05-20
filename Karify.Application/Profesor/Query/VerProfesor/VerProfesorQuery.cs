using MediatR;

namespace Karify.Application.Profesor.Query.VerProfesor
{
    public class VerProfesorQuery : IRequest<VerProfesorQueryDTO>
    {
        public int IdProfesor { get; set; }
    }
}
