using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor
{
    public class ObtenerProyectoPorProfesorQueryHandler : IRequestHandler<ObtenerProyectoPorProfesorQuery, IEnumerable<ObtenerProyectoPorProfesorQueryDTO>>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ILogger<ObtenerProyectoPorProfesorQueryHandler> _logger;

        public ObtenerProyectoPorProfesorQueryHandler(
            IProyectoRepository proyectoRepository,
            ILogger<ObtenerProyectoPorProfesorQueryHandler> logger)
        {
            _proyectoRepository = proyectoRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<ObtenerProyectoPorProfesorQueryDTO>> Handle(ObtenerProyectoPorProfesorQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener proyectos por profesor handler {handler}", GetType().Name);
            var response = await _proyectoRepository.ObtenerProyectoPorProfesor(request);
            this._logger.LogInformation("Finalizando proceso de obtener proyectos por profesor handler {handler}", GetType().Name);
            return response;
        }
    }
}
