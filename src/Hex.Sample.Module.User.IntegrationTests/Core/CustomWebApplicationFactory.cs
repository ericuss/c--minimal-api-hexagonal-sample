using Hex.Sample.Sdk;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Hex.Sample.Module.User.IntegrationTests.Core
{
    public class CustomWebApplicationFactory<TProgram>
     : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            const string url = "http://localhost:5136";
            builder
                .UseUrls(url)
                .ConfigureServices(services =>
                {
                    services.ConfigureUserPackage(url);

                });

            builder.UseEnvironment("Development");
        }
    }
}
