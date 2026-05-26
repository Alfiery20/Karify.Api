using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Profesor.Command.AgregarProfesor
{
    public class AgregarProfesorCommandHandler : IRequestHandler<AgregarProfesorCommand, AgregarProfesorCommandDTO>
    {
        private readonly ILogger<AgregarProfesorCommandHandler> _logger;
        private readonly IProfesorRepository _profesorRepository;

        public AgregarProfesorCommandHandler(
            ILogger<AgregarProfesorCommandHandler> logger,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._profesorRepository = profesorRepository;
        }
        public Task<AgregarProfesorCommandDTO> Handle(AgregarProfesorCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de agregar profesor handler {handler}", GetType().Name);
            var response = this._profesorRepository.AgregarProfesor(request);
            this._logger.LogInformation("Finalizando proceso de agregar profesor handler {handler}", GetType().Name);
            return response;
        }
    }
}
