using Karify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(MensajeUsuarioDTO message, Exception exception = null)
            : base(message, exception)
        {
        }
    }
}
