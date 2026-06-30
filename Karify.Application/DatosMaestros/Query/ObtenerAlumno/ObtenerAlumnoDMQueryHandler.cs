using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.DatosMaestros.Query.ObtenerAlumno
{
    public class ObtenerAlumnoDMQueryHandler : IRequestHandler<ObtenerAlumnoDMQuery, IEnumerable<ObtenerAlumnoDMQueryDTO>>
    {
        private readonly ILogger<ObtenerAlumnoDMQueryHandler> _logger;
        private readonly IDatosMaestrosRepository _datosMaestrosRepository;

        public ObtenerAlumnoDMQueryHandler(
            ILogger<ObtenerAlumnoDMQueryHandler> logger,
            IDatosMaestrosRepository datosMaestrosRepository)
        {
            this._logger = logger;
            this._datosMaestrosRepository = datosMaestrosRepository;
        }
        public Task<IEnumerable<ObtenerAlumnoDMQueryDTO>> Handle(ObtenerAlumnoDMQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando el handler para obtener alumnos");
            var response = this._datosMaestrosRepository.ObtenerAlumnoCotesista(request);
            this._logger.LogInformation("Finaliando el handler para obtener alumnos");
            return response;
        }
    }
}
