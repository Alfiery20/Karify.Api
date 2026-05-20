using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Rol.Command.AgregarRol
{
    public class AgregarRolCommandHandler : IRequestHandler<AgregarRolCommand, AgregarRolCommandDTO>
    {
        private readonly ILogger<AgregarRolCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public AgregarRolCommandHandler(
            ILogger<AgregarRolCommandHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<AgregarRolCommandDTO> Handle(AgregarRolCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de agregar rol handler {handler}", GetType().Name);
            var response = this._rolRepository.AgregarRol(request);
            this._logger.LogInformation("Finalizando proceso de agregar rol handler {handler}", GetType().Name);
            return response;
        }
    }
}
