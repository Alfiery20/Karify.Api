using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class EnvioCorreoSolicitudCotesista
    {
        public string CorreoCotesista { get; set; }
        public string Cotesista { get; set; }
        public string Alumno { get; set; }
        public String NombreProyecto { get; set; }
        public String DescripcionProyecto { get; set; }
    }
}
