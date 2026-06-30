using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AprobarProyectoCotesista
{
    public class EnvioCorreoTesistaAceptacion
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCotesista { get; set; }
        public string ApellidoPaternoCotesista { get; set; }
        public string ApellidoMaternoCotesista { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public string Correo { get; set; }
    }
}
