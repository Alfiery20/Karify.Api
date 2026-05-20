using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.DatosMaestros.Query.ObtenerProfesor
{
    public class ObtenerProfesorQueryDMHandler : IRequestHandler<ObtenerProfesorDMQuery, IEnumerable<ObtenerProfesorQueryDMDTO>>
    {
        private readonly ILogger<ObtenerProfesorQueryDMHandler> _logger;
        private readonly IDatosMaestrosRepository _datosMaestrosRepository;
        public ObtenerProfesorQueryDMHandler(
            ILogger<ObtenerProfesorQueryDMHandler> logger,
            IDatosMaestrosRepository datosMaestrosRepository)
        {
            this._logger = logger;
            this._datosMaestrosRepository = datosMaestrosRepository;
        }
        public Task<IEnumerable<ObtenerProfesorQueryDMDTO>> Handle(ObtenerProfesorDMQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener profesor handler {handler}", GetType().Name);
            var response = this._datosMaestrosRepository.ObtenerProfesorPorEscuela(request);
            this._logger.LogInformation("Finalizando proceso de obtener profesor handler {handler}", GetType().Name);
            return response;
        }
    }
}
