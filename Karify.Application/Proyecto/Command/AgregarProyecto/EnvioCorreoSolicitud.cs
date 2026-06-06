using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class EnvioCorreoSolicitud
    {
        public string CorreoDocente { get; set; }
        public string Alumno { get; set; }
        public int IdProyecto { get; set; }
        public String NombreProyecto { get; set; }
        public String DescripcionProyecto { get; set; }
    }
}
