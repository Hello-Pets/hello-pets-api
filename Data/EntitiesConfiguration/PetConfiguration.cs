using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.PublicId);

        builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);

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

        builder.Property(x => x.Furcolor).HasMaxLength(20).IsRequired(false);

        builder.Property(x => x.Neutered).HasDefaultValue(false);

        builder.Property(x => x.HasMicroChip).HasDefaultValue(false);

        builder.Property(x => x.Size);

        builder.OwnsOne(x => x.Breed).Property(x => x.Id);

        builder.OwnsOne(x => x.Breed).Property(x => x.Name).HasMaxLength(20).IsRequired(false);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.Id);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.Name).HasMaxLength(30).IsRequired(false);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.IsActive).HasDefaultValue(true);

        builder.OwnsOne(x => x.Breed).Property(x => x.IsActive).HasDefaultValue(true);

        builder.HasMany(x => x.UserPets).WithOne(x => x.Pet);
    }
}