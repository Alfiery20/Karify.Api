using Karify.Application.Common.Interface;
using Karify.Application.Common.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Karify.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<JwtService> _logger;

        public JwtService(
            IOptions<JwtSettings> jwtSettings,
            IDateTimeService dateTimeService,
            ILogger<JwtService> logger)
        {
            this._jwtSettings = jwtSettings.Value;
            this._dateTimeService = dateTimeService;
            this._logger = logger;
        }

        public string Generate(Claim[] claims, bool recordar, DateTime? experisUtc = null, string audience = null)
        {
            this._logger.LogInformation("Inicio de servicio de encriptación");
            var symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256Signature);
            var jwtSecurityToken = new JwtSecurityToken(
                        issuer: _jwtSettings.Issuer,
                        audience: audience,
                        claims: claims,
                        expires: recordar ? _dateTimeService.HoraActual().AddYears(1) : _dateTimeService.HoraActual().AddSeconds(_jwtSettings.ExpiresInSeconds),
                        signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            this._logger.LogInformation("Fin de servicio de encriptación");
            return token;
        }
    }
}
