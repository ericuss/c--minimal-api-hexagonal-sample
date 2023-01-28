using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hex.Sample.Module.User.Infrastructure.Database.Mappings;

public class UserMappings : IEntityTypeConfiguration<Domain.User>
{
    public void Configure(EntityTypeBuilder<Domain.User> builder)
    {
        builder.ToTable("Users", "Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
