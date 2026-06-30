using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AprobarProyectoCotesista
{
    public class AprobarProyectoCotesistaCommandHandler : IRequestHandler<AprobarProyectoCotesistaCommand, AprobarProyectoCotesistaCommandDTO>
    {
        private readonly ILogger<AprobarProyectoCotesistaCommandHandler> _logger;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IGoogleService _googleService;
        private readonly IProfesorRepository _profesorRepository;

        public AprobarProyectoCotesistaCommandHandler(
            ILogger<AprobarProyectoCotesistaCommandHandler> logger,
            IProyectoRepository proyectoRepository,
            IGoogleService googleService,
            IProfesorRepository profesorRepository)
        {
            this._logger = logger;
            this._proyectoRepository = proyectoRepository;
            this._googleService = googleService;
            this._profesorRepository = profesorRepository;
        }
        public async Task<AprobarProyectoCotesistaCommandDTO> Handle(AprobarProyectoCotesistaCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando handler de aprobar proyecto cotesista");
            var response = await this._proyectoRepository.AprobarProyectoCotesista(request);
            if (response.Mensaje.Equals("OK"))
            {
                await this.EnviarCorreoAprobacion(request.IdProyecto);
                await this.EnviarCorreoProfesor(request.IdProyecto);
            }
            this._logger.LogInformation("Fianlizando handler de aprobar proyecto cotesista");
            return response;
        }

        private async Task EnviarCorreoProfesor(int idProyecto)
        {
            var informacionCorreo = await this._proyectoRepository.ObtenerInformacionCorreoProfesor(idProyecto);
            await this._googleService.EnvioSolicitudAprobacion(new EnvioCorreoSolicitud()
            {
                CorreoDocente = informacionCorreo.Correo,
                Alumno = informacionCorreo.Alumno,
                IdProyecto = informacionCorreo.IdProyecto,
                NombreProyecto = informacionCorreo.NombreProyecto,
                DescripcionProyecto = informacionCorreo.DescripcionProyecto
            });
        }

        private async Task EnviarCorreoAprobacion(int idProyecto)
        {
            var informacionCorreo = await this._proyectoRepository.ObtenerInformacionCorreoCotesistaAprobacion(idProyecto);
            await this._googleService.EnvioNotificacionAprobacionCotesista(informacionCorreo);
        }
    }
}
