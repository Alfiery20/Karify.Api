using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Profesor.Command.EliminarProfesor
{
    public class EliminarProfesorCommandHandler : IRequestHandler<EliminarProfesorCommand, EliminarProfesorCommandDTO>
    {
        private readonly ILogger<EliminarProfesorCommandHandler> _logger;
        private readonly IProfesorRepository _profesorRepository;

        public EliminarProfesorCommandHandler(
            ILogger<EliminarProfesorCommandHandler> logger,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._profesorRepository = profesorRepository;
        }
        public Task<EliminarProfesorCommandDTO> Handle(EliminarProfesorCommand request, CancellationToken cancellationToken)
        {
            var response = this._profesorRepository.EliminarProfesor(request);
            return response;
        }
    }
}
