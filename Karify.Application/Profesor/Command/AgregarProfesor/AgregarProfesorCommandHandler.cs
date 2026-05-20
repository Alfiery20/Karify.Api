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
            var response = this._profesorRepository.AgregarProfesor(request);
            return response;
        }
    }
}
