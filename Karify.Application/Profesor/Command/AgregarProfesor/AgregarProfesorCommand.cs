using MediatR;

namespace Karify.Application.Profesor.Command.AgregarProfesor
{
    public class AgregarProfesorCommand : IRequest<AgregarProfesorCommandDTO>
    {
        public string Emeal { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdRol { get; set; }
    }
}
