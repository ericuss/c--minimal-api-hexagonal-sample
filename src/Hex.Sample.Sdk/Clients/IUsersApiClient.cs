using Hex.Sample.Sdk.Contracts.Users;

namespace Hex.Sample.Sdk.Clients
{
    public interface IUsersApiClient
    {
        Task<List<User>> GetAll();
    }
}