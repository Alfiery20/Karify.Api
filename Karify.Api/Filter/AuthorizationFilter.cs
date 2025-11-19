using Karify.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Karify.Api.Filter
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        string _key = "";
        string _issuer = "";

        public AuthorizationFilter(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._key = _configuration["JwtSettings:Key"] ?? "";
            this._issuer = _configuration["JwtSettings:Issuer"] ?? "";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (!request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            try
            {
                var handler = new JwtSecurityTokenHandler();

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key))
                };

                var principal = handler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;
                if (jwtToken != null)
                {
                    var claims = jwtToken.Claims;

                    var userId = claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "";
                    var userName = claims.FirstOrDefault(c => c.Type == "nombre")?.Value ?? "";
                    var userApellidoPaterno = claims.FirstOrDefault(c => c.Type == "apellido_paterno")?.Value ?? "";
                    var userApellidoMaterno = claims.FirstOrDefault(c => c.Type == "apellido_materno")?.Value ?? "";
                    var userFullName = claims.FirstOrDefault(c => c.Type == "nombre_completo")?.Value ?? "";
                    var rolId = claims.FirstOrDefault(c => c.Type == "id_rol")?.Value ?? "";
                    var rolName = claims.FirstOrDefault(c => c.Type == "rol_nombre")?.Value ?? "";

                    var currentUser = new CurrentUser()
                    {
                        Id = userId,
                        Nombre = userName,
                        ApellidoPaterno = userApellidoPaterno,
                        ApellidoMaterno = userApellidoMaterno,
                        NombreCompleto = userFullName,
                        RolId = rolId,
                        Rol = rolName
                    };

                    var currenUserSerialize = JsonConvert.SerializeObject(currentUser);

                    context.HttpContext.Session.SetString("dataUser", currenUserSerialize);
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
