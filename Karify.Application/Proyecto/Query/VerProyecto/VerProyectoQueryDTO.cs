namespace Karify.Application.Proyecto.Query.VerProyecto
{
    public class VerProyectoQueryDTO
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Profesor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
