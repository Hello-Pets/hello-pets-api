using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasIndex(x => x.PublicId).IsUnique();

        builder.Property(x => x.Name).HasMaxLength(121).IsRequired(true);

        builder.Property(x => x.Document).HasMaxLength(40).IsRequired(false);

        builder.Property(x => x.DocumentType);

        builder.Property(x => x.CreatedAt);

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.Property(x => x.PublicId).IsRequired(true);

        builder.Property(x => x.Bio).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Birthdate);

        builder.OwnsOne(x => x.File).Property(x => x.Id);

        builder.OwnsOne(x => x.File).Property(x => x.Name).HasMaxLength(100).IsRequired(false);

        builder.OwnsOne(x => x.File).Property(x => x.Type);

        builder.OwnsOne(x => x.File).Property(x => x.PublicLink).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Username).HasMaxLength(60).IsRequired(false);

        builder.Property(x => x.Password).IsRequired(true);

        builder.Property(x => x.Email).IsRequired(true);

        builder.Property(x => x.Salt).IsRequired(true);

        builder.Property(x => x.Phone).HasMaxLength(20).IsRequired(false);

        builder.Property(x => x.Address).HasMaxLength(120).IsRequired(false);

        builder.Property(x => x.UserType);

        builder.HasMany(x => x.UserPets).WithOne(x => x.User);
    }
}