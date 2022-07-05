// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace WorkforceMedicalNetwork.Api.Extensions
{
    /// <summary>
    ///     Extenstion methods for Microsoft.AspNetCore.Builder.IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        ///     setup swagger middleware for documentation
        /// </summary>
        /// <param name="app"></param>
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            Log.Information("WorkforceMedicalNetwork.UseSwaggerMiddleware enter");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // This sets the location to build the json
            // this must include the {documentName} in order for the json to be created at all
            app.UseSwagger(c =>
            {
                c.RouteTemplate = Constants.RouteTemplateString;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                // This tells the UI where to look for the json 
                c.SwaggerEndpoint(Constants.SwaggerEndpointString, Constants.SwaggerEndpointDescriptionString);

                // This sets where to find the UI
                c.RoutePrefix = Constants.RoutePrefixString;
            });

            return app;
        }

        /// <summary>
        ///     Sets up Global Exception Handling which also includes logging exceptions
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app, ILogger logger)
        {
            Log.Information("WorkforceMedicalNetwork.UseGlobalExceptionHandling enter");

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context => await GlobalException(context, logger));
            });
            return app;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static async Task<string> GlobalException(HttpContext context, ILogger logger)
        {
            Log.Information("WorkforceMedicalNetwork.GlobalException enter");
            context.Response.ContentType = Constants.HttpAcceptTypeJson;

            var exceptionHandlerPathFeature = context?.Features.Get<IExceptionHandlerPathFeature>();
            var ex = exceptionHandlerPathFeature?.Error;

            var problemDetails = new ProblemDetails();

            //for exceptions thrown by Kestrel like too large header, too large payload etc. have its own status codes, details etc.
            if (ex is BadHttpRequestException badHttpRequestException)
            {
                problemDetails.Title = "Invalid request";
                problemDetails.Status = badHttpRequestException.StatusCode;
                context.Response.StatusCode = badHttpRequestException.StatusCode;
                problemDetails.Detail = badHttpRequestException.Message;
            }
            else
            {
                problemDetails.Title = "An unexpected error occurred!!!";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //Note: Do NOT expose sensitive information to client 
            }

            if (ex != null)
            {
                await Task.Run(() =>
                {
                    logger?.LogError(ex, "### Global Exception Handler handled an unexpected error!! ###");
                }).ConfigureAwait(false);
            }
            var jsonProblemDetails = JsonConvert.SerializeObject(problemDetails);
            await context?.Response.WriteAsync(jsonProblemDetails);
            return jsonProblemDetails;
        }
    }
}