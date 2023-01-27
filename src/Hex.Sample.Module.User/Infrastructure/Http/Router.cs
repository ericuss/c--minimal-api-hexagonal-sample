namespace Hex.Sample.Module.User.Infrastructure.Http;

using Hex.Sample.Module.User.Application.Users;
using Microsoft.AspNetCore.Builder;

public static class Router
{
    public static WebApplication RegisterUserRoutes(this WebApplication app)
    {
        //const string route = "/api/v{version:apiVersion}/users";
        const string route = "/api/users";

        app.MapGet(route, _ => GetAllUsersFeature.Handle());
        return app;
    }
}
