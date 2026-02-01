using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerEscuela
{
    public class ObtenerEscuelaQueryHandler : IRequestHandler<ObtenerEscuelaQuery, IEnumerable<ObtenerEscuelaQueryDTO>>
    {
        private readonly ILogger<ObtenerEscuelaQueryHandler> _logger;
        private readonly IDatosMaestrosRepository _datosMaestrosRepository;

        public ObtenerEscuelaQueryHandler(
            ILogger<ObtenerEscuelaQueryHandler> logger,
            IDatosMaestrosRepository datosMaestrosRepository)
        {
            this._logger = logger;
            this._datosMaestrosRepository = datosMaestrosRepository;
        }
        public Task<IEnumerable<ObtenerEscuelaQueryDTO>> Handle(ObtenerEscuelaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener escuela handler {handler}", GetType().Name);
            var response = this._datosMaestrosRepository.ObtenerEscuela(request);
            this._logger.LogInformation("Finalizando proceso de obtener escuela handler {handler}", GetType().Name);
            return response;
        }
    }
}
