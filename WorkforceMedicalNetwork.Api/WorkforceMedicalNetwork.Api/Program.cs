// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace WorkforceMedicalNetwork.Api
{
    public static class Program
    {
        public static ILogger Logger { get; set; }

        /// <summary>
        ///     Entry method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Log.Information("WorkforceMedicalNetwork.Main enter");
            try
            {
                BuildLogger();
                CreateHostBuilder(args);
            }
            catch (Exception e)
            {
                Log.Fatal(e, Constants.HostTerminatedString);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BuildLogger()
        {
            Log.Information("WorkforceMedicalNetwork.BuildLogger enter");
            var env = System.Environment.GetEnvironmentVariable(Constants.EnvironmentVariableString);
            var loggerConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{env}.json", true)
                .AddEnvironmentVariables()
                .Build();

            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(loggerConfiguration)
                .CreateLogger();
        }

        /// <summary>
        ///     Build default Web Host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static void CreateHostBuilder(string[] args)
        {
            Log.Information("WorkforceMedicalNetwork.UseGlobalExceptionHandling enter");

            if (args == null) return;
            WebHost.CreateDefaultBuilder(args).
                UseStartup<Startup>().
                UseSerilog(Logger).
                Build().Run();
        }
    }
}

