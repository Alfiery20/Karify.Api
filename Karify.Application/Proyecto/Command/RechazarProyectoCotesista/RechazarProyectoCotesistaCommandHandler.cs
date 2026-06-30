using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.RechazarProyectoCotesista
{
    public class RechazarProyectoCotesistaCommandHandler : IRequestHandler<RechazarProyectoCotesistaCommand, RechazarProyectoCotesistaCommandDTO>
    {
        private readonly ILogger<RechazarProyectoCotesistaCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IGoogleService _googleService;

        public RechazarProyectoCotesistaCommandHandler(
            ILogger<RechazarProyectoCotesistaCommandHandler> logger,
            IProyectoRepository proyectoRepository,
            IGoogleService googleService)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
            this._googleService = googleService;
        }
        public async Task<RechazarProyectoCotesistaCommandDTO> Handle(RechazarProyectoCotesistaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler de rechazo de proyecto cotesista");
            var response = await this._proyectoRepository.RechazarProyectoCotesista(request);
            if (response.Mensaje.Equals("OK"))
            {
                await this.EnviarCorreoRechazo(request.IdProyecto);
            }
            this._logger.LogInformation("Finalizando handler de rechazo de proyecto cotesista");
            return response;
        }

        private async Task EnviarCorreoRechazo(int idProyecto)
        {
            var informacionCorreo = await this._proyectoRepository.ObtenerInformacionCorreoCotesistaRechazo(idProyecto);
            await this._googleService.EnvioNotificacionRechazoCotesista(informacionCorreo);
        }
    }
}
