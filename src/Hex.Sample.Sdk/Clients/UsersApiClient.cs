using Hex.Sample.Sdk.Constants;
using Hex.Sample.Sdk.Contracts.Users;
using Newtonsoft.Json;

namespace Hex.Sample.Sdk.Clients
{
    public class UsersApiClient : IUsersApiClient
    {
        private readonly HttpClient _httpClient;

        public UsersApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<User>> GetAll()
        {
            var uri = $"{this._httpClient.BaseAddress}{Routes.Users}";

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var result = await _httpClient.SendAsync(request);
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(content);
        }
    }
}
