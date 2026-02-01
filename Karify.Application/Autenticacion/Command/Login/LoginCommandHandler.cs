using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Karify.Application.Autenticacion.Command.LoginGoogle
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandDTO>
    {
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly IGoogleService _googleService;
        private readonly IAutenticacionRepository _autenticacionRepository;
        private readonly IJwtService _jwtService;
        private readonly IDateTimeService _dateTimeService;

        public LoginCommandHandler(
            ILogger<LoginCommandHandler> logger,
            IGoogleService googleService,
            IAutenticacionRepository autenticacionRepository,
            IJwtService jwtService,
            IDateTimeService dateTimeService
            )
        {
            this._logger = logger;
            this._googleService = googleService;
            this._autenticacionRepository = autenticacionRepository;
            this._jwtService = jwtService;
            this._dateTimeService = dateTimeService;
        }
        public async Task<LoginCommandDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Iniciando proceso de login con Google en handler {handler}", GetType().Name);
            var infoGoogle = await this._googleService.GoogleDecryptToken(request);
            using JsonDocument doc = JsonDocument.Parse(infoGoogle);
            JsonElement root = doc.RootElement;

            string Correo = root.GetProperty("email").GetString();
            string Nombre = root.GetProperty("given_name").GetString();
            string Apellido = root.GetProperty("family_name").GetString();
            string Dominio = String.Empty;
            if (root.TryGetProperty("hd", out var hdElement) && hdElement.ValueKind == JsonValueKind.String)
            {
                Dominio = hdElement.GetString() ?? string.Empty;
            }

            if (!Dominio.Equals("unprg.edu.pe"))
            {
                return new LoginCommandDTO()
                {
                    IdUsuario = -1
                };
            }

            var response = await this._autenticacionRepository.IniciarSesion(new LoginGoogleCommand
            {
                Email = Correo,
                Nombre = Nombre,
                Apellido = Apellido
            });
            if (response.IdUsuario != 0)
            {
                response.Token = this.GenerateToken(response, true);
                response.Menus = (await this._autenticacionRepository.ObtenerMenu(response.IdRol)).ToArray();
            }
            this._logger.LogInformation("Finalizando proceso de login con Google en handler {handler}", GetType().Name);
            return response;
        }

        private string GenerateToken(LoginCommandDTO command, bool recordar)
        {
            var claims = new List<Claim>
            {
                new Claim("id", command.IdUsuario.ToString() ?? ""),
                new Claim("codigoUniversitario", command.CodigoUniversitario ?? ""),
                new Claim("tipo_documento", command.TipoDocumento ?? ""),
                new Claim("numero_documento", command.NumeroDocumento ?? ""),
                new Claim("nombre", command.Nombre ?? ""),
                new Claim("apellido_paterno", command.ApellidoPaterno ?? ""),
                new Claim("apellido_materno", command.ApellidoMaterno ?? ""),
                new Claim("correo", command.Correo ?? ""),
                new Claim("telefono", command.Telefono ?? ""),
                new Claim("idEscuela", command.IdEscuela.ToString() ?? ""),
                new Claim("nombreEscuela", command.NombreEscuela ?? ""),
                new Claim("idFacultad", command.IdFacultad.ToString() ?? ""),
                new Claim("nombreFacultad", command.NombreFacultad ?? ""),
                new Claim("esNecesarioLlenar", command.LLenarPerfil.ToString() ?? ""),
                new Claim("idRol", command.IdRol.ToString() ?? ""),
                new Claim("rol", command.Rol ?? "")
            };

            var token = _jwtService.Generate(claims.ToArray(), recordar, this._dateTimeService.HoraLocal());

            return token;
        }
    }
}
