using Karify.Application.Common.Dtos;

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
