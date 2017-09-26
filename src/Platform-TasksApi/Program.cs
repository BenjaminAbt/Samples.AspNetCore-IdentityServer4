using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApi
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
                .UseUrls(ApiSampleOptions.ApiUrl)
                .Build();
    }
}
