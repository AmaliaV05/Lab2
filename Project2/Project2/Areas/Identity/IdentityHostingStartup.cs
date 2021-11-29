using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Project2.Areas.Identity.IdentityHostingStartup))]
namespace Project2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}