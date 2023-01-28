using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hex.Sample.Infrastructure.Contexts;
public static class ContextInitialize
{
    public static async Task InitializeDb<T>(T context, IConfiguration configuration, string sqlSectionKey)
        where T : DbContext
    {
        var sqlOptions = configuration.GetSection(sqlSectionKey).Get<SqlOptions>() ?? throw new Exception("Cannot fill sqlOptions in module user");
        if (sqlOptions.Migrate)
        {
            if (sqlOptions.EnsureDeleted)
            {
                await context.Database.EnsureDeletedAsync();
            }
            context.Database.Migrate();
        }
    }
}