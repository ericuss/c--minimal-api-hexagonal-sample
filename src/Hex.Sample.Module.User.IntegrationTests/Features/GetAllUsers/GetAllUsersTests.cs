using Hex.Sample.Module.User.IntegrationTests.Core;
using Hex.Sample.Sdk.Clients;

namespace Hex.Sample.Module.User.IntegrationTests.Features.GetAllUsers
{
    public class BasicTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public BasicTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetUsers_HappyPath()
        {
            var userApiClient = new UsersApiClient(_factory.CreateClient());
            var response = await userApiClient.GetAll();

            Assert.NotNull(response);
            Assert.Equal(2, response.Count);
        }
    }

}
