using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Profesor.Query.VerProfesor
{
    public class VerProfesorQueryHandler : IRequestHandler<VerProfesorQuery, VerProfesorQueryDTO>
    {
        private readonly ILogger<VerProfesorQueryHandler> _logger;
        private readonly IProfesorRepository _profesorRepository;

        public VerProfesorQueryHandler(
            ILogger<VerProfesorQueryHandler> logger,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._profesorRepository = profesorRepository;
        }
        public Task<VerProfesorQueryDTO> Handle(VerProfesorQuery request, CancellationToken cancellationToken)
        {
            var response = this._profesorRepository.VerProfesor(request);
            return response;
        }
    }
}
