using AutoMapper;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Command.EliminarRol
{
    public class EliminarRolCommandHandler : IRequestHandler<EliminarRolCommand, EliminarRolCommandDTO>
    {
        private readonly ILogger<EliminarRolCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public EliminarRolCommandHandler(
            ILogger<EliminarRolCommandHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<EliminarRolCommandDTO> Handle(EliminarRolCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de eliminar rol handler {handler}", GetType().Name);
            var response = this._rolRepository.EliminarRol(request);
            this._logger.LogInformation("Finalizando proceso de eliminar rol handler {handler}", GetType().Name);
            return response;
        }
    }
}
