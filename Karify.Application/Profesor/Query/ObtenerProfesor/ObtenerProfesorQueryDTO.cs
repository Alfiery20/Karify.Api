namespace Karify.Application.Profesor.Query.ObtenerProfesor
{
    public class ObtenerProfesorQueryDTO
    {
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string CodigoUniversitario { get; set; }
        public string Correo { get; set; }
        public string Facultad { get; set; }
        public string Escuela { get; set; }
        public bool CompletarPerfil { get; set; }
    }
}
