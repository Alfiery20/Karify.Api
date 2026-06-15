namespace Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor
{
    public class ObtenerProyectoPorProfesorQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Alumno { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
