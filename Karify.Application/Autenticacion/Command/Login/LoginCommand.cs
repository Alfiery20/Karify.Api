using MediatR;

namespace Karify.Application.Autenticacion.Command.LoginGoogle
{
    public class LoginCommand : IRequest<LoginCommandDTO>
    {
        public string Token { get; set; }
    }
}
