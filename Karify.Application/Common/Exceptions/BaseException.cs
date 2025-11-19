using Karify.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(MensajeUsuarioDTO message, Exception exception = null)
            : base(message.Descripcion, exception)
        {
            MensajeUsuario = message;
        }

        public MensajeUsuarioDTO MensajeUsuario { get; }
    }
}
