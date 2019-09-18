using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VFSolution.PIM.Persistence;

namespace VFSolution.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Delay(20000).Wait();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                VFInitializer.Init(scope.ServiceProvider);
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((buildercontext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
