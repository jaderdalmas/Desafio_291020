using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;

namespace Api.StartUp
{
    /// <summary>
    /// Health Check
    /// </summary>
    public static class HealthCheck
    {
        private const string URL_CHECK = "/health-check";

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="configuration">Configuration</param>
        public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
        }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app">Application</param>
        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            //app.UseHealthChecks(URL_CHECK,
            //    new HealthCheckOptions()
            //    {
            //        ResponseWriter = async (context, report) =>
            //        {
            //            var result = JsonConvert.SerializeObject(
            //                new
            //                {
            //                    statusApplication = report.Status.ToString(),
            //                    healthChecks = report.Entries.Select(e => new
            //                    {
            //                        check = e.Key,
            //                        status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
            //                    })
            //                }, Formatting.Indented);
            //            context.Response.ContentType = MediaTypeNames.Application.Json;
            //            await context.Response.WriteAsync(result);
            //        }
            //    }
            //);
        }
    }
}
