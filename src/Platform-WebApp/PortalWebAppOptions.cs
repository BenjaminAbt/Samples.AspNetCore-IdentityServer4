namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_PortalWebApp
{
    public static class PortalWebAppOptions
    {
        // Options
        public const string IdentityServerHost = "http://localhost:9010";

        public const string ClientId = "Platform.WebClient";
        public const string ClientSecret = "webclient-secret";

        public const string TodoApiUrl = "http://localhost:9011";
        public const string PortalWebUrl = "http://localhost:9012";
    }
}