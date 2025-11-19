using Karify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Exceptions
{
    public class DeleteFailureException : BaseException
    {
        public DeleteFailureException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
