namespace Karify.Application.Profesor.Query.VerProfesor
{
    public class VerProfesorQueryDTO
    {
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string CodigoUniversitario { get; set; }
        public string Correo { get; set; }
        public int Facultad { get; set; }
        public int Escuela { get; set; }
    }
}
