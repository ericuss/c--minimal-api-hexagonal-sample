namespace Hex.Sample.Module.User.Infrastructure.Http;
using global::Hex.Sample.Module.User.Infrastructure.Database;

using Hex.Sample.Module.User.Application.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

public static class Router
{
    public static WebApplication RegisterUserRoutes(this WebApplication app)
    {
        //const string route = "/api/v{version:apiVersion}/users";
        const string route = "/api/users";

        app.MapGet(route, async ([FromServices] UsersContext context) => await GetAllUsersFeature.Handle(context));
        return app;
    }
}
