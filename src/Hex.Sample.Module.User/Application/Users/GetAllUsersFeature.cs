using Hex.Sample.Module.User.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hex.Sample.Module.User.Application.Users;

public static class GetAllUsersFeature
{
    public static async Task<IResult> Handle(UsersContext context)
    {
        var entities = await context.Users.ToListAsync();  
        return Results.Ok(entities);
    }
}