using Karify.Application.Autenticacion.Command.LoginGoogle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface
{
    public interface IGoogleService
    {
        Task<string> GoogleDecryptToken(LoginCommand command);
    }
}
