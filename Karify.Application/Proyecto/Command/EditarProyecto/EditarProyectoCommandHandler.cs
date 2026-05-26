using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Command.EditarProyecto
{
    public class EditarProyectoCommandHandler : IRequestHandler<EditarProyectoCommand, EditarProyectoCommandDTO>
    {
        private readonly ILogger<EditarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;

        public EditarProyectoCommandHandler(
            ILogger<EditarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
        }
        public Task<EditarProyectoCommandDTO> Handle(EditarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de editar proyecto handler {handler}", GetType().Name);
            var response = this._proyectoRepository.EditarProyecto(request);
            this._logger.LogInformation("Finalizando proceso de editar proyecto handler {handler}", GetType().Name);
            return response;
        }
    }
}
