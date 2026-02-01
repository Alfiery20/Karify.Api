using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerFacultad
{
    public class ObtenerFacultadQueryHandler : IRequestHandler<ObtenerFacultadQuery, IEnumerable<ObtenerFacultadQueryDTO>>
    {
        private readonly ILogger<ObtenerFacultadQueryHandler> _logger;
        private readonly IDatosMaestrosRepository _datosMaestrosRepository;

        public ObtenerFacultadQueryHandler(
            ILogger<ObtenerFacultadQueryHandler> logger,
            IDatosMaestrosRepository datosMaestrosRepository)
        {
            this._logger = logger;
            this._datosMaestrosRepository = datosMaestrosRepository;
        }
        public Task<IEnumerable<ObtenerFacultadQueryDTO>> Handle(ObtenerFacultadQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener facultad handler {handler}", GetType().Name);
            var response = this._datosMaestrosRepository.ObtenerFacultad();
            this._logger.LogInformation("Finalizando proceso de obtener facultad handler {handler}", GetType().Name);
            return response;
        }
    }
}
