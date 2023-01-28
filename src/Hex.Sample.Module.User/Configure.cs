using Hex.Sample.Infrastructure.Contexts;
using Hex.Sample.Module.User.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Hex.Sample.Module.User;

public static class Configure
{
    private const string SqlSectionKey = "Sql";
    public static IServiceCollection ConfigureUsers(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlOptions = configuration.GetSection(SqlSectionKey).Get<SqlOptions>() ?? throw new Exception("Cannot fill sqlOptions in module user");
        return services
                .RegisterDB(sqlOptions)
                .Configure<SqlOptions>(configuration.GetSection(SqlSectionKey))
                ;
    }


    private static IServiceCollection RegisterDB(this IServiceCollection services, SqlOptions sqlOptions)
    {
        services.AddDbContext<UsersContext>(o => o.UseSqlServer(sqlOptions.ConnectionString, x =>
            x.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2000), null)
        ), ServiceLifetime.Transient);

        return services;
    }
}
