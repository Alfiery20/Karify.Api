using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Common.Interface;
using Microsoft.Extensions.Logging;

namespace Karify.Infrastructure.Services
{
    public class GoogleService : IGoogleService
    {
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
    }
}
