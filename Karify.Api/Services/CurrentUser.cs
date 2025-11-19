using Karify.Application.Common.Interface;

namespace Karify.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string RolId { get; set; }
        public string Rol { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoUniversitario { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEscuela { get; set; }
        public string Escuela { get; set; }
    }
}
