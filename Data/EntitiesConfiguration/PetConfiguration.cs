using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasIndex(x => x.PublicId);

        builder.Property(x => x.Name).HasMaxLength(30).IsRequired(false);

        builder.Property(x => x.Document).HasMaxLength(40).IsRequired(false);

        builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.Property(x => x.Bio).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Furcolor).HasMaxLength(20).IsRequired(false);

        builder.HasMany(x => x.UserPets).WithOne(x => x.Pet);
    }
}