using Microsoft.Azure.Cosmos;

namespace Hex.Sample.Infrastructure.Cosmos;

public class CustomCosmosClient
{
    private readonly CosmosClient _client;
    private readonly Database _db;
    public readonly Container Container;

    public CustomCosmosClient(CosmosOptions cosmosOptions, string container)
    {
        CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
        {
            HttpClientFactory = () =>
            {
                HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                return new HttpClient(httpMessageHandler);
            },
            ConnectionMode = ConnectionMode.Gateway,
            SerializerOptions = new CosmosSerializationOptions
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            }
        };

        _client = new CosmosClient(
            connectionString: cosmosOptions.ConnectionString,
            clientOptions: cosmosClientOptions
        );
        _db = _client.GetDatabase(cosmosOptions.Database);
        Container = _db.GetContainer(container);
    }
}
