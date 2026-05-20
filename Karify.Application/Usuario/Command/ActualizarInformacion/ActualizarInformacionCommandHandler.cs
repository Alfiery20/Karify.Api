using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Usuario.Command.ActualizarInformacion
{
    public class ActualizarInformacionCommandHandler : IRequestHandler<ActualizarInformacionCommand, ActualizarInformacionCommandDTO>
    {
        private readonly ILogger<ActualizarInformacionCommandHandler> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public ActualizarInformacionCommandHandler(
            ILogger<ActualizarInformacionCommandHandler> logger,
            IUsuarioRepository usuarioRepository)
        {
            this._logger = logger;
            this._usuarioRepository = usuarioRepository;
        }
        public Task<ActualizarInformacionCommandDTO> Handle(ActualizarInformacionCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de actualizar informacion personal handler {handler}", GetType().Name);
            var response = this._usuarioRepository.ActualizarInformacionPersonal(request);
            this._logger.LogInformation("Finalizando proceso de actualizar informacion personal handler {handler}", GetType().Name);
            return response;
        }
    }
}
