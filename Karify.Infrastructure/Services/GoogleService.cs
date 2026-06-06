using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Common.Interface;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace Karify.Infrastructure.Services
{
    public class GoogleService : IGoogleService   
    {
        private readonly IConfiguration _configuration;
        public GoogleService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<string> GoogleDecryptToken(LoginCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = new HttpClientHandler
            {
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            using var httpClient = new HttpClient(handler);

            // Cabecera correcta:
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", command.Token);

            var response = await httpClient.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;
                throw new Exception($"Google error: {response.StatusCode} - {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task EnvioCorreo(EnvioCorreoSolicitud envioCorreo)
        {
            string
                Servidor = this._configuration["GmailCredential:Servidor"] ?? "",
                Correo = this._configuration["GmailCredential:Correo"] ?? "",
                Clave = this._configuration["GmailCredential:Clave"] ?? "";
            int PuertoTLS = Convert.ToInt32(this._configuration["GmailCredential:PuertoTLS"]),
                PuertoSSL = Convert.ToInt32(this._configuration["GmailCredential:PuertoSSL"]);
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(Correo, Clave),
                EnableSsl = true
            };
            var htmlBody = await File.ReadAllTextAsync("Templates/SolicitudAceptacionDocente.html");

            htmlBody = htmlBody.Replace("{{Alumno}}", envioCorreo.Alumno)
                            .Replace("{{NombreProyecto}}", envioCorreo.NombreProyecto)
                            .Replace("{{DescripcionProyecto}}", envioCorreo.DescripcionProyecto)
                            .Replace("{{LINK_ACEPTACION}}", $"https://portal.universidad.edu/proyectos/aceptar/{envioCorreo.IdProyecto}");
            var mail = new MailMessage
            {
                From = new MailAddress( "rfurlong@unprg.edu.pe",
                                    "Sistema de Gestión de Proyectos"),

                Subject = "Nueva asignación de proyecto",
                Body = htmlBody,
                IsBodyHtml = true
            };

            mail.To.Add(envioCorreo.CorreoDocente);

            await smtp.SendMailAsync(mail);
        }
    }
}
