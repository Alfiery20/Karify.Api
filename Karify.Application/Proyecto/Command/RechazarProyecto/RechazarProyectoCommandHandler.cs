using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Command.RechazarProyecto
{
    public class RechazarProyectoCommandHandler : IRequestHandler<RechazarProyectoCommand, RechazarProyectoCommandDTO>
    {
        private readonly ILogger<RechazarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IGoogleService _googleService;

        public RechazarProyectoCommandHandler(
            ILogger<RechazarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository,
            IGoogleService googleService)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
            this._googleService = googleService;
        }
        public async Task<RechazarProyectoCommandDTO> Handle(RechazarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler de rechazar proyecto");
            var response = await this._proyectoRepository.RechazarProyecto(request);
            if (response.Mensaje.Equals("OK"))
            {
                var informacionRechazo = (await this._proyectoRepository.ObtenerInformacionRechazo(request.IdProyecto)).ToList();
                foreach (var item in informacionRechazo)
                {
                    await this._googleService.EnvioNotificacionRechazo(item);

                }
            }
            this._logger.LogInformation("Finalizando handler de rechazar proyecto");
            return response;
        }
    }
}
