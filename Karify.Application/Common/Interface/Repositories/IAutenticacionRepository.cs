using Karify.Application.Autenticacion.Command.Login;
using Karify.Application.Autenticacion.Command.LoginGoogle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IAutenticacionRepository
    {
        Task<LoginCommandDTO> IniciarSesion(LoginGoogleCommand query);
        Task<IEnumerable<Menu>> ObtenerMenu(int IdRol);
    }
}
