using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_IdentityServerHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentityServer()
                        .AddDeveloperSigningCredential(filename: "tempkey.rsa")
                        .AddInMemoryApiResources(IdentityServerSampleConfig.GetApiResources())
                        .AddInMemoryIdentityResources(IdentityServerSampleConfig.GetIdentityResources())
                        .AddInMemoryClients(IdentityServerSampleConfig.GetClients())
                        .AddTestUsers(IdentityServerSampleConfig.GetUsers());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment envloggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
