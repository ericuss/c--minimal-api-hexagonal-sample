using Microsoft.Extensions.DependencyInjection;

namespace Hex.Sample.Module.User
{

    public static class Configure
    {
        public static IServiceCollection ConfigureUsers(this IServiceCollection services)
        {
            return services;
        }
    }
}
