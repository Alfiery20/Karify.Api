using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class AgregarProyectoCommandHandler : IRequestHandler<AgregarProyectoCommand, AgregarProyectoCommandDTO>
    {
        private readonly ILogger<AgregarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public AgregarProyectoCommandHandler(
            ILogger<AgregarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<AgregarProyectoCommandDTO> Handle(AgregarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de agregar proyecto handler {handler}", GetType().Name);
            var response = this._proyectoRepository.AgregarProyecto(request);
            this._logger.LogInformation("Finalizando proceso de agregar proyecto handler {handler}", GetType().Name);
            return response;
        }
    }
}
