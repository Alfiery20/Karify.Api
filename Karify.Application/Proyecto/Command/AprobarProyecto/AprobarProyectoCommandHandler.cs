using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Command.AprobarProyecto
{
    public class AprobarProyectoCommandHandler : IRequestHandler<AprobarProyectoCommand, AprobarProyectoCommandDTO>
    {
        private readonly ILogger<AprobarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IGoogleService _googleService;

        public AprobarProyectoCommandHandler(
            ILogger<AprobarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository,
            IGoogleService googleService)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
            this._googleService = googleService;
        }
        public async Task<AprobarProyectoCommandDTO> Handle(AprobarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de aprobación del proyecto.");
            var response = await this._proyectoRepository.AprobarProyecto(request);
            if (response.Mensaje.Equals("OK"))
            {
                var informacionArpobacion = await this._proyectoRepository.ObtenerInformacionAprobacion(request.IdProyecto);
                await this._googleService.EnvioNotificacionAprobacion(informacionArpobacion);
            }
            this._logger.LogInformation("Finalizando proceso de aprobación del proyecto.");
            return response;
        }
    }
}
