using Karify.Application.Common.Behaviours;
using Karify.Application.Common.Settings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Karify.Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddSingleton<CustomJsonResolver>();

            return services;
        }
    }
}
