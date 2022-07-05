// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using WorkforceMedicalNetwork.Api.Extensions;
using WorkforceMedicalNetwork.Api.Interfaces;
using WorkforceMedicalNetwork.Api.Services;

namespace WorkforceMedicalNetwork.Api
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        /// <summary>
        ///     Constructor for startup class that takes IConfiguration as input parameter. This parameter gets injected at
        ///     runtime.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            Log.Information("WorkforceMedicalNetwork.ConfigureServices enter");

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    //This is to keep the endpoints from automatically throwing 400 errors when
                    //the received model has a null value for one of its fields - for
                    //security reasons, we don't want the api telling whoever's
                    //hitting it that some responses are accepted and some are not.
                    options.SuppressModelStateInvalidFilter = true;
                });
            services.AddCorsConfiguration();
            services.AddSwagger();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IRegisterService, RegisterService>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<HttpClient>();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.Information("WorkforceMedicalNetwork.Configure enter");

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseGlobalExceptionHandling(_logger);

            app.UseSwaggerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Constants.ApiCorsPolicyName);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}