using AutoMapper;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Command.EditarRol
{
    public class EditarRolCommandHandler : IRequestHandler<EditarRolCommand, EditarRolCommandDTO>
    {
        private readonly ILogger<EditarRolCommandHandler> _logger;
        private readonly IRolRepository _rolRepository;

        public EditarRolCommandHandler(
            ILogger<EditarRolCommandHandler> logger,
            IRolRepository rolRepository)
        {
            this._logger = logger;
            this._rolRepository = rolRepository;
        }
        public Task<EditarRolCommandDTO> Handle(EditarRolCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de editar rol handler {handler}", GetType().Name);
            var response = this._rolRepository.EditarRol(request);
            this._logger.LogInformation("Finalizando proceso de editar rol handler {handler}", GetType().Name);
            return response;
        }
    }
}
