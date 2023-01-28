namespace Hex.Sample.Infrastructure.Contexts;

public class SqlOptions
{
    public string ConnectionString { get; set; } = default!;

    public bool DetailedErrors { get; set; }

    public bool Migrate { get; set; }

    public bool EnsureDeleted { get; set; }

    public bool ApplySeed { get; set; }

}