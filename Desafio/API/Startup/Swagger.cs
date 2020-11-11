using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Api.StartUp
{
    /// <summary>
    /// Api Swagger
    /// </summary>
    public static class Swagger
    {
        /// <summary>
        /// Register swagger
        /// </summary>
        /// <param name="services">Service collection</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                services.AddSwaggerGen(swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "My API" });
                });

                ////Show Authorize
                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"", Name = "Authorization", Type = "apiKey" });
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() }, });

                //// Set the comments path for the Swagger JSON and UI.
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Api.xml");
                //c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="app">App builder</param>
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
        }
    }
}
