using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Profesor.Query.ObtenerProfesor
{
    public class ObtenerProfesorQueryHandler : IRequestHandler<ObtenerProfesorQuery, IEnumerable<ObtenerProfesorQueryDTO>>
    {
        private readonly ILogger<ObtenerProfesorQueryHandler> _logger;
        private readonly IProfesorRepository _profesorRepository;

        public ObtenerProfesorQueryHandler(
            ILogger<ObtenerProfesorQueryHandler> logger,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._profesorRepository = profesorRepository;
        }
        public Task<IEnumerable<ObtenerProfesorQueryDTO>> Handle(ObtenerProfesorQuery request, CancellationToken cancellationToken)
        {
            var response = this._profesorRepository.ObtenerProfesor(request);
            return response;
        }
    }
}
