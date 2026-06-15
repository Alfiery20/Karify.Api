namespace Karify.Application.Proyecto.Query.VerProyectoRevision
{
    public class VerProyectoRevisionQueryDTO
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreArchivo { get; set; }
        public string Archivo { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoUniversitario { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoPateno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}
