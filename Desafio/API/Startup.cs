using Api.Filter;
using Api.StartUp;
using API.Helpers;
using API.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace API
{
    /// <summary>
    /// Application Start Up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="configuration">Application Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Application Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service Collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionsFilter>();
            });
            services.AddAuthentication(AuthenticationSchemes.Basic.ToString())
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AuthenticationSchemes.Basic.ToString(), null);

            services.AddExternalServices();
            services.AddServices();

            services.AddCompression();
            services.AddHealthCheck();
            services.AddSwagger();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">WebHost Environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCompression();
            app.ConfigureHealthCheck();
            app.ConfigureSwagger();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
