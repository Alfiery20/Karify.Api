using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Common.Interface;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace Karify.Infrastructure.Services
{
    public class GoogleService : IGoogleService
    {
        private readonly IConfiguration _configuration;
        private readonly string servidor;
        private readonly string correo;
        private readonly string clave;
        private readonly int puertoTLS;
        public GoogleService(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.servidor = this._configuration["GmailCredential:Servidor"] ?? "";
            this.correo = this._configuration["GmailCredential:Correo"] ?? "";
            this.clave = this._configuration["GmailCredential:Clave"] ?? "";
            this.puertoTLS = Convert.ToInt32(this._configuration["GmailCredential:PuertoTLS"]);
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
        public async Task EnvioSolicitudAprobacion(EnvioCorreoSolicitud envioCorreo)
        {
            string
                Servidor = this.servidor,
                Correo = this.correo,
                Clave = this.clave;
            int PuertoTLS = this.puertoTLS;
            var smtp = new SmtpClient(Servidor, PuertoTLS)
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
                From = new MailAddress(Correo, "Sistema de Gestión de Proyectos"),

                Subject = "Nueva asignación de proyecto",
                Body = htmlBody,
                IsBodyHtml = true
            };

            mail.To.Add(envioCorreo.CorreoDocente);

            await smtp.SendMailAsync(mail);
        }
        public async Task EnvioNotificacionAprobacion(AprobacionProyectoCorreo aprobacion)
        {
            string
                Servidor = this.servidor,
                Correo = this.correo,
                Clave = this.clave;
            int PuertoTLS = this.puertoTLS;
            var smtp = new SmtpClient(Servidor, PuertoTLS)
            {
                Credentials = new NetworkCredential(Correo, Clave),
                EnableSsl = true
            };
            var htmlBody = await File.ReadAllTextAsync("Templates/AprobacionProyecto.html");

            htmlBody = htmlBody
                        .Replace("{{NumeroDocumento}}", aprobacion.NumeroDocumento)
                        .Replace("{{CodigoUniversitario}}", aprobacion.CodigoUniversitario)
                        .Replace("{{Correo}}", aprobacion.Correo)
                        .Replace("{{Nombre}}", aprobacion.Nombre)
                        .Replace("{{ApellidoPaterno}}", aprobacion.ApellidoPaterno)
                        .Replace("{{ApellidoMaterno}}", aprobacion.ApellidoMaterno)
                        .Replace("{{NombreProfesor}}", aprobacion.NombreProfesor)
                        .Replace("{{ApellidoPaternoProfesor}}", aprobacion.ApellidoPaternoProfesor)
                        .Replace("{{ApellidoMaternoProfesor}}", aprobacion.ApellidoMaternoProfesor)
                        .Replace("{{NombreProyecto}}", aprobacion.NombreProyecto)
                        .Replace("{{DescripcionProyecto}}", aprobacion.DescripcionProyecto)
                        .Replace("{{FechaResultado}}", aprobacion.FechaResultado.ToString("dd/MM/yyyy HH:mm"));

            var mail = new MailMessage
            {
                From = new MailAddress(Correo, "Sistema de Gestión de Proyectos"),

                Subject = "Nueva asignación de proyecto",
                Body = htmlBody,
                IsBodyHtml = true
            };

            mail.To.Add(aprobacion.Correo);

            await smtp.SendMailAsync(mail);
        }
        public async Task EnvioNotificacionRechazo(RechazoProyectoCorreo aprobacion)
        {
            string
                Servidor = this.servidor,
                Correo = this.correo,
                Clave = this.clave;
            int PuertoTLS = this.puertoTLS;
            var smtp = new SmtpClient(Servidor, PuertoTLS)
            {
                Credentials = new NetworkCredential(Correo, Clave),
                EnableSsl = true
            };
            var htmlBody = await File.ReadAllTextAsync("Templates/RechazoProyecto.html");

            htmlBody = htmlBody
                        .Replace("{{NumeroDocumento}}", aprobacion.NumeroDocumento)
                        .Replace("{{CodigoUniversitario}}", aprobacion.CodigoUniversitario)
                        .Replace("{{Correo}}", aprobacion.Correo)
                        .Replace("{{Nombre}}", aprobacion.Nombre)
                        .Replace("{{ApellidoPaterno}}", aprobacion.ApellidoPaterno)
                        .Replace("{{ApellidoMaterno}}", aprobacion.ApellidoMaterno)
                        .Replace("{{NombreProfesor}}", aprobacion.NombreProfesor)
                        .Replace("{{ApellidoPaternoProfesor}}", aprobacion.ApellidoPaternoProfesor)
                        .Replace("{{ApellidoMaternoProfesor}}", aprobacion.ApellidoMaternoProfesor)
                        .Replace("{{NombreProyecto}}", aprobacion.NombreProyecto)
                        .Replace("{{DescripcionProyecto}}", aprobacion.DescripcionProyecto)
                        .Replace("{{FechaResultado}}", aprobacion.FechaResultado.ToString("dd/MM/yyyy HH:mm"));

            var mail = new MailMessage
            {
                From = new MailAddress(Correo, "Sistema de Gestión de Proyectos"),

                Subject = "Nueva asignación de proyecto",
                Body = htmlBody,
                IsBodyHtml = true
            };

            mail.To.Add(aprobacion.Correo);

            await smtp.SendMailAsync(mail);
        }
    }
}
