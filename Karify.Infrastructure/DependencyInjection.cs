using Karify.Application.Common.Interface;
using Karify.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<ICryptography, Cryptography>();
            return services;
        }
    }
}
