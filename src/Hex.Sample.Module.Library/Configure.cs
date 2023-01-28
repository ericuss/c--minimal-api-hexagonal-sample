using Hex.Sample.Infrastructure.Cosmos;
using Hex.Sample.Module.Library.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hex.Sample.Module.Library;


public static class Configure
{
    private const string CosmosSectionKey = "Cosmos";
    public static IServiceCollection ConfigureLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        var cosmosOptions = configuration.GetSection(CosmosSectionKey).Get<CosmosOptions>() ?? throw new Exception("Cannot fill cosmosOptions in module library");
        return services
                .Configure<CosmosOptions>(configuration.GetSection(CosmosSectionKey))
                .AddScoped<IBookRepository, BookRepository>()
                ;
    }
}
