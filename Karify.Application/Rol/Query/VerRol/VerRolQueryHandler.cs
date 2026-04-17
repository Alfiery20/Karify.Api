using AutoMapper;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Query.VerRol
{
    public class VerRolQueryHandler : IRequestHandler<VerRolQuery, VerRolQueryDTO>
    {
        private readonly ILogger<VerRolQueryHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public VerRolQueryHandler(
            ILogger<VerRolQueryHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public async Task<VerRolQueryDTO> Handle(VerRolQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de ver rol handler {handler}", GetType().Name);
            var response = await this._rolRepository.VerRol(request);
            response.Permisos = (await this._rolRepository.ObtenerPermiso(request.IdRol)).ToArray();
            this._logger.LogInformation("Finalizando proceso de ver rol handler {handler}", GetType().Name);
            return response;
        }
    }
}
