using AutoMapper;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Query.ObtenerRol
{
    public class ObtenerRolQueryHandler : IRequestHandler<ObtenerRolQuery, IEnumerable<ObtenerRolQueryDTO>>
    {
        private readonly ILogger<ObtenerRolQueryHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public ObtenerRolQueryHandler(
            ILogger<ObtenerRolQueryHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<IEnumerable<ObtenerRolQueryDTO>> Handle(ObtenerRolQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener rol handler {handler}", GetType().Name);
            var response = this._rolRepository.ObtenerRol(request);
            this._logger.LogInformation("Finalizando proceso de obtener rol handler {handler}", GetType().Name);
            return response;
        }
    }
}
