using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Query.VerProyectoRevision
{
    public class VerProyectoRevisionQueryHandler : IRequestHandler<VerProyectoRevisionQuery, VerProyectoRevisionQueryDTO>
    {
        private readonly ILogger<VerProyectoRevisionQueryHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public VerProyectoRevisionQueryHandler(
            ILogger<VerProyectoRevisionQueryHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<VerProyectoRevisionQueryDTO> Handle(VerProyectoRevisionQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler Ver Proyecto Revision");
            var response = this._proyectoRepository.VerProyectoRevision(request);
            this._logger.LogInformation("Finalizando handler Ver Proyecto Revision");
            return response;
        }
    }
}
