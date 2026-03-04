using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karify.Application.Usuario.Query.ObtenerInformacionUsuario
{
    public class ObtenerInformacionUsuarioQueryHandler : IRequestHandler<ObtenerInformacionUsuarioQuery, ObtenerInformacionUsuarioQueryDTO>
    {
        private readonly ILogger<ObtenerInformacionUsuarioQueryHandler> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public ObtenerInformacionUsuarioQueryHandler(
            ILogger<ObtenerInformacionUsuarioQueryHandler> logger,
            IUsuarioRepository usuarioRepository)
        {
            this._logger = logger;
            this._usuarioRepository = usuarioRepository;
        }
        public Task<ObtenerInformacionUsuarioQueryDTO> Handle(ObtenerInformacionUsuarioQuery request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de obtener informacion personal handler {handler}", GetType().Name);
            var response = this._usuarioRepository.ObtenerInformacionPersonal(request);
            this._logger.LogInformation("Finalizando proceso de obtener informacion personal handler {handler}", GetType().Name);
            return response;
        }
    }
}
