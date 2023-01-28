using Hex.Sample.Sdk.Clients;
using Hex.Sample.Sdk.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Hex.Sample.Sdk
{
    public static class Configure
    {
        public static IServiceCollection ConfigureUserPackage(this IServiceCollection services, string baseAddress)
        {
            return services.AddHttpService<IUsersApiClient, UsersApiClient>(new Uri(baseAddress));
        }
    }
}
