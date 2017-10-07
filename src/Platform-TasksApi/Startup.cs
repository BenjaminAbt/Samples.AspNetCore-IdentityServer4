using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApi
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                {

                    // === FOR DEMO ONLY
                    options.RequireHttpsMetadata = false;
                    // SET THIS TO true IN PRODUCTION!

                    options.Authority = ApiSampleOptions.IdentityServerHost;
                    options.ApiName = ApiSampleOptions.ApiClientId;
                });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
