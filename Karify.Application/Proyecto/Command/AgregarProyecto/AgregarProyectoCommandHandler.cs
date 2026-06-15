using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class AgregarProyectoCommandHandler : IRequestHandler<AgregarProyectoCommand, AgregarProyectoCommandDTO>
    {
        private readonly ILogger<AgregarProyectoCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProfesorRepository _profesorRepository;
        private readonly IGoogleService _googleService;

        public AgregarProyectoCommandHandler(
            ILogger<AgregarProyectoCommandHandler> logger,
            IProyectoRepository proyectoRepository,
            IProfesorRepository profesorRepository,
            IGoogleService googleService)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
            this._profesorRepository = profesorRepository;
            this._googleService = googleService;
        }
        public async Task<AgregarProyectoCommandDTO> Handle(AgregarProyectoCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de agregar proyecto handler {handler}", GetType().Name);
            var response = await this._proyectoRepository.AgregarProyecto(request);
            if (response.Mensaje.Equals("OK"))
            {
                var correoProfesor = await this._profesorRepository.ObtenerCorreoProfesor(request.IdProfesor);
                await this._googleService.EnvioSolicitudAprobacion(new EnvioCorreoSolicitud()
                {
                    CorreoDocente = correoProfesor,
                    Alumno = request.NombreAlumno,
                    IdProyecto = response.IdProyecto,
                    NombreProyecto = request.Nombre,
                    DescripcionProyecto = request.Descripcion
                });
            }
            this._logger.LogInformation("Finalizando proceso de agregar proyecto handler {handler}", GetType().Name);
            return response;
        }
    }
}
