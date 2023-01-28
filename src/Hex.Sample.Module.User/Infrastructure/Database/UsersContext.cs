using Hex.Sample.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hex.Sample.Module.User.Infrastructure.Database;

public class UsersContext : ContextCore<UsersContext>
{
    public UsersContext(DbContextOptions<UsersContext> options, IOptions<SqlOptions> sqlOptions)
        : base(options, sqlOptions)
    {
    }

    public DbSet<Domain.User> Users { get; set; }
}
