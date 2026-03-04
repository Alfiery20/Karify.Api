using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Usuario.Command.ActualizarInformacion
{
    public class ActualizarInformacionCommand : IRequest<ActualizarInformacionCommandDTO>
    {
        public int IdUsuario { get; set; }
        public string CodigoUniversitario  { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public int IdEscuela { get; set; }
    }
}
