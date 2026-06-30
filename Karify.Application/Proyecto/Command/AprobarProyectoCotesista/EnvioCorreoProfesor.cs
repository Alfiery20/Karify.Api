using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AprobarProyectoCotesista
{
    public class EnvioCorreoProfesor
    {
        public int IdProyecto { get; set; }
        public string Correo { get; set; }
        public string Alumno { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
    }
}
