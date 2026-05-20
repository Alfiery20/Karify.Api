using Karify.Application.Autenticacion.Command.LoginGoogle;

namespace Karify.Application.Common.Interface
{
    public interface IGoogleService
    {
        Task<string> GoogleDecryptToken(LoginCommand command);
    }
}
