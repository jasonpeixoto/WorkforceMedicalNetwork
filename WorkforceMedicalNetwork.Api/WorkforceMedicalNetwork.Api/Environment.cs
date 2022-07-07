// ///////////////////////////////////////////////////////////////////////////////////
// 
// 
// ////////////////////////////////////////////////////////////////////////////////////


namespace WorkforceMedicalNetwork.Api
{
    public static class Environment
    {
        public static string CouchbaseEndpoint =>
            GetEnvironmentVariable("CouchbaseEndpoint", "couchbase://172.17.0.3");
        public static string CouchbaseUser =>
            GetEnvironmentVariable("CouchbaseUser", "demo");
        public static string CouchbasePassword =>
            GetEnvironmentVariable("CouchbasePassword", "demo");
        public static string Key =>
            GetEnvironmentVariable("Key", "0123456789012345");
        public static string OktaServerUrl =>
            GetEnvironmentVariable("OktaServerUrl", "https://auth.myokta.com/");
        public static string OktaApiToken =>
            GetEnvironmentVariable("OktaApiToken", "00vi1D2e5SiNJIlRrXbYKoenn19WJKdxGcYk5MBo1a");
        public static string EnvironmentVariableString =>
            "ASPNETCORE_ENVIRONMENT";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(string environment, string defaultValue)
        {
            string value = System.Environment.GetEnvironmentVariable(environment);

            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }

            // determine if we are running in docker if not we are running under unit testing so return default
            if (System.Environment.GetEnvironmentVariable(EnvironmentVariableString) == null)
            {
                return defaultValue;
            }

            // throw Exception if running in docker and Environment is missing
            throw new System.ArgumentException("Environment cannot be null", environment);
        }
    }
}
