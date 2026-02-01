using Karify.Application.Autenticacion.Command.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Autenticacion.Command.LoginGoogle
{
    public class LoginCommandDTO
    {
        public int IdUsuario { get; set; }
        public string CodigoUniversitario { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdEscuela { get; set; }
        public string NombreEscuela { get; set; }
        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; }
        public bool LLenarPerfil { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public Menu[] Menus { get; set; }
        public string Token { get; set; }
    }
}
