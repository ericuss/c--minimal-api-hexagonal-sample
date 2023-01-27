using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Hex.Sample.Sdk.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddHttpService<TInterface, TImplementation>(this IServiceCollection serviceCollection, Uri baseUrl)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            return serviceCollection
                    .AddHttpClient<TInterface, TImplementation>(typeof(TInterface).AssemblyQualifiedName, x => x.BaseAddress = baseUrl)
                    .AddPolicyHandler(ApplyRetryPolicy())
                    //.AddHttpMessageHandler<>
                    .Services
                    ;
        }

        private static Func<HttpRequestMessage, IAsyncPolicy<HttpResponseMessage>> ApplyRetryPolicy()
        {
            return x => x.Method== HttpMethod.Get
                    ? HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(2, retryAttemp => TimeSpan.FromSeconds(2))
                    : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();
        }
    }
}
