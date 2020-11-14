using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace API.Repository
{
    /// <summary>
    /// Inject Repositories
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        /// <summary>
        /// Add Repositories in the service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <returns>service collection</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserMemory, UserMemory>();
            services.AddHostedService(service => service.GetService<IUserMemory>());

            services.AddScoped<IUserRepository>(resolver => resolver.GetRequiredService<IUserMemory>());
            services.AddScoped<IAuthRepository, AuthRepository>();

            return services;
        }
    }
}
