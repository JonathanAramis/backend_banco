using backend.Interfaces.Repositories;
using backend.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace backend.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class IoCConfiguration
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();

            return services;
        }
    }
}
