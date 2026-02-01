using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Autenticacion.Command.LoginGoogle
{
    public class LoginCommand : IRequest<LoginCommandDTO>
    {
        public string Token { get; set; }
    }
}
