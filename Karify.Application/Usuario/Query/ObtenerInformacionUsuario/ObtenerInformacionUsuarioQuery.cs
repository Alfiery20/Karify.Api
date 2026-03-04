using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Usuario.Query.ObtenerInformacionUsuario
{
    public class ObtenerInformacionUsuarioQuery : IRequest<ObtenerInformacionUsuarioQueryDTO>
    {
        public int IdUsuario { get; set; }
    }
}
