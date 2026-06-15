using MediatR;

namespace Karify.Application.Profesor.Command.EditarProfesor
{
    public class EditarProfesorCommand : IRequest<EditarProfesorCommandDTO>
    {
        public int IdProfesor { get; set; }
        public string Emeal { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdRol { get; set; }
    }
}
