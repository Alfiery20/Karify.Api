using Karify.Application.Common.Dtos;

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
