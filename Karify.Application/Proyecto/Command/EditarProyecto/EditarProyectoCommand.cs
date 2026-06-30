using MediatR;

namespace Karify.Application.Proyecto.Command.EditarProyecto
{
    public class EditarProyectoCommand : IRequest<EditarProyectoCommandDTO>
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdAlumno { get; set; }
        public int IdCotesista { get; set; }
        public int IdProfesor { get; set; }
    }
}
