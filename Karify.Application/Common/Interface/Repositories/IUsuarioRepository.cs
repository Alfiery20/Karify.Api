using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        Task<ObtenerInformacionUsuarioQueryDTO> ObtenerInformacionPersonal(ObtenerInformacionUsuarioQuery query);
    }
}
