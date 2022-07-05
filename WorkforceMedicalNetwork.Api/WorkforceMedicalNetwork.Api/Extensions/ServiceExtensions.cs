// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

namespace WorkforceMedicalNetwork.Api.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        ///     Setup swagger service
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            Log.Information("WorkforceMedicalNetwork.AddSwagger enter");

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = Constants.OpenApiInfoString,
                    Version = "v1",
                    Description = Constants.OpenApiInfoDescriptionString
                });

                // Setup Swagger to read from XML comments in the assembly. 
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                o.IncludeXmlComments(xmlPath);

                //add authorization functionality - to enter bearer token and add bearer token to all api calls
                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        @"JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }

        /// <summary>
        ///     Adds CORS
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            Log.Information("WorkforceMedicalNetwork.AddCorsConfiguration enter");

            services.AddCors(corsOptions =>
            {
                //todo: refine the policy once more information about the usage of this Api is known
                corsOptions.AddPolicy(Constants.ApiCorsPolicyName, policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}