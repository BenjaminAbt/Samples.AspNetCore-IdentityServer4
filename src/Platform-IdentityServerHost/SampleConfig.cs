using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_IdentityServerHost
{
    public static class IdentityServerSampleConfig
    {
        public const string IdentityHost = "http://localhost:9010";

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Platform.TodoApi", "Sample Todo API Client")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
  

                new Client
                {
                    ClientId = "External.WebApp",
                    ClientName = "External WebApp",
                    ClientSecrets = { new Secret("external-webapp-secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowOfflineAccess = true,

                    // === 'true' for external applications so the user have to authorize the external webapp
                    RequireConsent = true,

                    RedirectUris = { "http://localhost:9015/signin-oidc" }, // Url of the WebApp Client
                    PostLogoutRedirectUris = { "http://localhost:9015/signout-callback-oidc" }, // Url of the WebApp Client
                    
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Platform.TodoApi"
                    },
                },

                new Client
                {
                    ClientId = "Platform.WebClient",
                    ClientName = "WebApp MVC Client", 
                    ClientSecrets = { new Secret("webclient-secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowOfflineAccess = true,
                    
                    // === 'false' for trusted platform clients so the user will not have to accept the application
                    RequireConsent = false,

                    RedirectUris = { "http://localhost:9012/signin-oidc" }, // Url of the WebApp Client
                    PostLogoutRedirectUris = { "http://localhost:9012/signout-callback-oidc" }, // Url of the WebApp Client
                    
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Platform.TodoApi"
                    },
                },

                new Client
                {
                    ClientId = "Platform.AdminConsoleClient",
                    ClientName = "AdminConsole Client",
                    ClientSecrets = { new Secret("adminconsole-secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes =
                    {
                        "Platform.TodoApi"
                    },
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "ben",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Benjamin Abt"),
                        new Claim("nickname", "Ben"),
                        new Claim("website", "https://www.BenjaminAbt.com"),
                        new Claim("linkedin", "https://www.linkedin.com/in/benjaminabt/"),
                        new Claim("twitter", "https://www.twitter.com/abt_benjamin"),
                    }
                }
            };
        }
    }
}
