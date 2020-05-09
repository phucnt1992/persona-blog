using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persona.IdentityServer.Extensions;

namespace Persona.IdentityServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            var env = webHost.Services.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                await webHost.SeedIdentityDatabaseAsync();
                await webHost.SeedSuperAdminAccountAsync();
            }

            await webHost.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
