using Karify.Application.Autenticacion.Command.Login;
using Karify.Application.Autenticacion.Command.LoginGoogle;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IAutenticacionRepository
    {
        Task<LoginCommandDTO> IniciarSesion(LoginGoogleCommand query);
        Task<IEnumerable<Menu>> ObtenerMenu(int IdRol);
    }
}
