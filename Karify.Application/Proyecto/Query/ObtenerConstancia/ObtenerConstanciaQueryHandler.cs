using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Query.ObtenerConstancia
{
    public class ObtenerConstanciaQueryHandler : IRequestHandler<ObtenerConstanciaQuery, ObtenerConstanciaQueryDTO>
    {
        private readonly ILogger<ObtenerConstanciaQueryHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public ObtenerConstanciaQueryHandler(
            ILogger<ObtenerConstanciaQueryHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<ObtenerConstanciaQueryDTO> Handle(ObtenerConstanciaQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Inicializando handler para obtener constancia");
            var response = this._proyectoRepository.ObtenerConstancia(request);
            this._logger.LogInformation("Finalizando handler para obtener constancia");
            return response;
        }
    }
}
