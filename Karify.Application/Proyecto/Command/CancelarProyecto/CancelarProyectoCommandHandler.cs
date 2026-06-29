using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.CancelarProyecto
{
    public class CancelarProyectoCommandHandler : IRequestHandler<CancelarProyectoCommand, CancelarProyectoCommandDTO>
    {
        private readonly ILogger<CancelarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public CancelarProyectoCommandHandler(
            ILogger<CancelarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<CancelarProyectoCommandDTO> Handle(CancelarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler de cancelacion de proyecto por usuario");
            var response = this._proyectoRepository.CancelarProyecto(request);
            this._logger.LogInformation("Finalizando handler de cancelacion de proyecto por usuario");
            return response;
        }
    }
}
