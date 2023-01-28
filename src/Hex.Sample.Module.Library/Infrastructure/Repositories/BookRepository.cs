using Hex.Sample.Infrastructure.Cosmos;
using Hex.Sample.Module.Library.Domain;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;

namespace Hex.Sample.Module.Library.Infrastructure.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
    }

    public class BookRepository : IBookRepository
    {
        private readonly CustomCosmosClient _client;

        public BookRepository(IOptions<CosmosOptions> cosmosOptions)
        {
            _client = new CustomCosmosClient(cosmosOptions.Value, "books");
        }

        public async Task<List<Domain.Book>> GetAll()
        {
            var queryable = _client.Container.GetItemLinqQueryable<Domain.Book>();

            using FeedIterator<Domain.Book> feed = queryable
                .OrderByDescending(p => p.Name)
                .ToFeedIterator();

            List<Domain.Book> results = new();

            while (feed.HasMoreResults)
            {
                var response = await feed.ReadNextAsync();
                foreach (Domain.Book item in response)
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }
}
