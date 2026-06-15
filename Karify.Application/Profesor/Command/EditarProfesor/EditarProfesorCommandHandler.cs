using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Profesor.Command.EditarProfesor
{
    public class EditarProfesorCommandHandler : IRequestHandler<EditarProfesorCommand, EditarProfesorCommandDTO>
    {
        private readonly ILogger<EditarProfesorCommandHandler> _logger;
        private readonly IProfesorRepository _profesorRepository;

        public EditarProfesorCommandHandler(
            ILogger<EditarProfesorCommandHandler> logger,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._profesorRepository = profesorRepository;
        }
        public Task<EditarProfesorCommandDTO> Handle(EditarProfesorCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de editar profesor handler {handler}", GetType().Name);
            var response = this._profesorRepository.EditarProfesor(request);
            this._logger.LogInformation("Finalizando proceso de editar profesor handler {handler}", GetType().Name);
            return response;
        }
    }
}
