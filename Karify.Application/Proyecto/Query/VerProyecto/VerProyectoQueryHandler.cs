using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Query.VerProyecto
{
    public class VerProyectoQueryHandler : IRequestHandler<VerProyectoQuery, VerProyectoQueryDTO>
    {
        private readonly ILogger<VerProyectoQueryHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public VerProyectoQueryHandler(
            ILogger<VerProyectoQueryHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<VerProyectoQueryDTO> Handle(VerProyectoQuery request, CancellationToken cancellationToken)
        {
            var response = this._proyectoRepository.VerProyecto(request);
            return response;
        }
    }
}
