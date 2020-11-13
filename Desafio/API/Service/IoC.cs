using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;

namespace API.Service
{
    /// <summary>
    /// Inject Services 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        /// <summary>
        /// Add Services in the service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <returns>service collection</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Services
            services.AddSingleton<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Add External Services in the service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <returns>service collection</returns>
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            // External Services
            services.AddHttpClient<IJuntosSomosMaisService, JuntosSomosMaisService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
