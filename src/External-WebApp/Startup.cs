using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.External_WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddOpenIdConnect(options =>
                {
                    // === FOR DEMO ONLY
                    options.RequireHttpsMetadata = false;
                    // SET THIS TO true IN PRODUCTION!

                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    options.Authority = ExternalWebAppOptions.IdentityServerHost;
                    options.ClientId = ExternalWebAppOptions.ClientId;
                    options.ClientSecret = ExternalWebAppOptions.ClientSecret;

                    options.ResponseType = "code id_token";
                    options.SaveTokens = true;

                    options.Scope.Add("Platform.TodoApi");
                    options.Scope.Add("offline_access");
                });

            services.AddMvc();



            // Todo API Settings

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // singleton is safe here, see https://github.com/aspnet/Hosting/issues/793

            services.AddTransient<IRestApiHttpClient, AspNetCoreHttpContextBearerAuthorizedApiClient>();
            services.AddTransient<TodoApiClient>(x =>
                new TodoApiClient(x.GetService<IRestApiHttpClient>(), ExternalWebAppOptions.TodoApiUrl));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
