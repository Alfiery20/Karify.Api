using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Persistence.Database;
using Karify.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Karify.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SqlDataBase(connectionString));

            services.AddSingleton<IAutenticacionRepository, AutenticacionRepository>();
            services.AddSingleton<IDatosMaestrosRepository, DatosMaestrosRepository>();

            return services;
        }
    }
}
