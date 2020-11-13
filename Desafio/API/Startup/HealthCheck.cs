using API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Api.StartUp
{
    /// <summary>
    /// Health Check
    /// </summary>
    public static class HealthCheck
    {
        private const string URL_CHECK = "/health";

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<IJuntosSomosMaisService>("JSM");
        }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app">Application</param>
        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks(URL_CHECK, new HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(new
                    {
                        statusApplication = report.Status.ToString(),
                        healthChecks = report.Entries.Select(e => new
                        {
                            check = e.Key,
                            status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                            description = (e.Value.Status != HealthStatus.Healthy) ? e.Value.Description : string.Empty
                        })
                    }, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = true });
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result).ConfigureAwait(false);
                }
            });
        }
    }
}
