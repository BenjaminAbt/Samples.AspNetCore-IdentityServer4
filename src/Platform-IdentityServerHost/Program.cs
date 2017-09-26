using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_IdentityServerHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(IdentityServerSampleConfig.IdentityHost)
                .Build();
    }
}
