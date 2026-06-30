namespace Karify.Application.Proyecto.Query.ObtenerProyecto
{
    public class ObtenerProyectoQueryDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Profesor { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsCotesista { get; set; }
    }
}
