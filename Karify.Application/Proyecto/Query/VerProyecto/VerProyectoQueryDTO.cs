namespace Karify.Application.Proyecto.Query.VerProyecto
{
    public class VerProyectoQueryDTO
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int Profesor { get; set; }
        public string NombreProfesor { get; set; }
        public int Cotesista { get; set; }
        public string NombreCotesista { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsCotesista { get; set; }
    }
}
