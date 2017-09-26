namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.External_WebApp
{
    public static class ExternalWebAppOptions
    {

        public const string AppUrl = "http://localhost:9015";

        // Options
        public const string IdentityServerHost = "http://localhost:9010";

        public const string ClientId = "External.WebApp";
        public const string ClientSecret = "external-webapp-secret";

        public const string TodoApiUrl = "http://localhost:9011";
    }
}