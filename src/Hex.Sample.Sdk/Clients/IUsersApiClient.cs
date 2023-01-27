using Hex.Sample.Sdk.Contracts;

namespace Hex.Sample.Sdk.Clients
{
    public interface IUsersApiClient
    {
        Task<List<User>> GetAll();
    }
}