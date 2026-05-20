using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Query.ObtenerProyecto
{
    public class ObtenerProyectoQueryHandler : IRequestHandler<ObtenerProyectoQuery, IEnumerable<ObtenerProyectoQueryDTO>>
    {
        private readonly ILogger<ObtenerProyectoQueryHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public ObtenerProyectoQueryHandler(
            ILogger<ObtenerProyectoQueryHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<IEnumerable<ObtenerProyectoQueryDTO>> Handle(ObtenerProyectoQuery request, CancellationToken cancellationToken)
        {
            var response = this._proyectoRepository.ObtenerProyecto(request);
            return response;
        }
    }
}
