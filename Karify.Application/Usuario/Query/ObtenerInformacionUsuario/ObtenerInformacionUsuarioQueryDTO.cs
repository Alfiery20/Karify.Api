using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Usuario.Query.ObtenerInformacionUsuario
{
    public class ObtenerInformacionUsuarioQueryDTO
    {
        public int Id { get; set; }
        public string CodigoUniversitario { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdFacultad { get; set; }
        public int IdEscuela { get; set; }
    }
}
