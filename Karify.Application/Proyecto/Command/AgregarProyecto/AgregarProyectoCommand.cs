using MediatR;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class AgregarProyectoCommand : IRequest<AgregarProyectoCommandDTO>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdAlumno { get; set; }
        public string NombreCotesista { get; set; }
        public int IdCotesista{ get; set; }
        public int IdProfesor { get; set; }
        public string NombreArchivo { get; set; }
        public string ArchivoEncriptado { get; set; }
        public double Peso { get; set; }
        public string NombreAlumno { get; set; }
    }
}
