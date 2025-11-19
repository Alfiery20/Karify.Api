using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface
{
    public interface ICurrentUser
    {
        string Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoUniversitario { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEscuela { get; set; }
        public string Escuela { get; set; }
        string RolId { get; set; }
        string Rol { get; set; }
    }
}
