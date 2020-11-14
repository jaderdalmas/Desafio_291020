using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Net;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API" });

                c.AddSecurityDefinition(AuthenticationSchemes.Basic.ToString(), new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = AuthenticationSchemes.Basic.ToString(),
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = AuthenticationSchemes.Basic.ToString()
                        }
                    },
                    new string[] {}
                }});
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
