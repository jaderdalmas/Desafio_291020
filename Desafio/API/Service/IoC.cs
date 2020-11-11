using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace API.Service
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<IJuntosSomosMaisService, JuntosSomosMaisService>();

            return services;
        }
    }
}
