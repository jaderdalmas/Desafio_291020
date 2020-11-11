using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace API.Repository
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();

            return services;
        }
    }
}
