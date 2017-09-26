namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApi
{
    public static class ApiSampleOptions
    {
        // Options
        public const string IdentityServerHost = "http://localhost:9010";

        public const string ApiClientId = "Platform.TodoApi";
        public const string ApiUrl = "http://localhost:9011"; // should be the same like launchsettings.json
    }
}