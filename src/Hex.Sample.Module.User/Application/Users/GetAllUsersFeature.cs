using Microsoft.AspNetCore.Http;

namespace Hex.Sample.Module.User.Application.Users
{
    public static class GetAllUsersFeature
    {
        public static Task<IResult> Handle()
        {
            var entities = new List<Sdk.Contracts.User>(){
                                new Sdk.Contracts.User{Name = "User 01"},
                                new Sdk.Contracts.User{Name = "User 02"},
                            };

            return Task.FromResult(Results.Ok(entities));
        }
    }

}