using System;
using System.Collections.Generic;
using System.Text;

namespace WorkforceMedicalNetwork.Api.UnitTests.TestFramework
{
    public class TestConstants
    {
        public const string EmailAddress = "demo@demo.com";
        public const string Password = "password";

        public const string StartingWebHostString = "Starting web host for Workforce Medical Network API";
        public static string HostTerminatedString = "Host terminated unexpectedly for Workforce Medical Network API.";
        public static string EnvironmentVariableString = "ASPNETCORE_ENVIRONMENT";

        public const string InvalidEndpoint = "/api/unknown/Endpoint";
        public const string LoginEndpoint = "/api/login";
        public const string LocationEndpoint = "/api/location";
        public const string RegisterEndpoint = "/api/register";
    }
}
