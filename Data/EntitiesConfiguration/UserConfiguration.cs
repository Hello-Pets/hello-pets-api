using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasIndex(x => x.PublicId).IsUnique();

        builder.Property(x => x.Document).HasMaxLength(32).IsRequired(false);

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.Property(x => x.Bio).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Username).HasMaxLength(64).IsRequired(false);

        builder.Property(x => x.Phone).HasMaxLength(32).IsRequired(false);

        builder.Property(x => x.Address).HasMaxLength(122).IsRequired(false);

        builder.HasMany(x => x.UserPets).WithOne(x => x.User);
    }
}