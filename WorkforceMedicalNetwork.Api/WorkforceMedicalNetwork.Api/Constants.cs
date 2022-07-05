// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////

namespace WorkforceMedicalNetwork.Api
{
    public static class Constants
    {
        public static string OktaAuthEndpoint => @"/api/v1/authn";
        
        public static string RoutePrefixString => "api/swagger";

        public static string HttpAcceptTypeJson => "application/json";

        public static string ApiCorsPolicyName => "SubmitFactorApiPolicy";

        public static string SSWS => "SSWS";

        public static string StartingWebHostString => "Starting web host for Workforce Medical Network API";

        public static string HostTerminatedString => "Host terminated unexpectedly for Workforce Medical Network API.";

        public static string EnvironmentVariableString => "ASPNETCORE_ENVIRONMENT";

        public static string SwaggerEndpointDescriptionString => "Workforce Medical Network API v1";

        public static string OpenApiInfoString => "Workforce Medical Network API";

        public static string OpenApiInfoDescriptionString => "APIs for managing calls for Workforce Medical Network and App";

        public static string RouteTemplateString => $"{RoutePrefixString}/{{documentName}}/swagger.json";

        public static string SwaggerEndpointString => $"/{RoutePrefixString}/v1/swagger.json";
    }
}