using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);

        builder.Property(x => x.Document).HasMaxLength(40).IsRequired(false);

        builder.Property(x => x.DocumentType).IsRequired(false);

        builder.Property(x => x.CreatedAt).IsRequired(true);

        builder.Property(x => x.UpdatedAt).IsRequired(false);

        builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.PublicId).IsRequired(true);

        builder.Property(x => x.Bio).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Birthdate).IsRequired(false);

        builder.OwnsOne(x => x.File).Property(x => x.Id).IsRequired(false);

        builder.OwnsOne(x => x.File).Property(x => x.Name).HasMaxLength(100).IsRequired(false);

        builder.OwnsOne(x => x.File).Property(x => x.Type).IsRequired(false);

        builder.OwnsOne(x => x.File).Property(x => x.PublicLink).HasMaxLength(255).IsRequired(false);

        builder.Property(x => x.Furcolor).HasMaxLength(20).IsRequired(false);

        builder.Property(x => x.Neutered).HasDefaultValue(false).IsRequired(false);

        builder.Property(x => x.HasMicroChip).HasDefaultValue(false).IsRequired(false);

        builder.Property(x => x.Size).IsRequired(false);

        builder.OwnsOne(x => x.Breed).Property(x => x.Id).IsRequired(false);

        builder.OwnsOne(x => x.Breed).Property(x => x.Name).HasMaxLength(20).IsRequired(false);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.Id).IsRequired(false);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.Name).HasMaxLength(30).IsRequired(false);

        builder.OwnsOne(x => x.Breed).OwnsOne(x => x.Specie).Property(x => x.IsActive).HasDefaultValue(true).IsRequired(false);

        builder.OwnsOne(x => x.Breed).Property(x => x.IsActive).HasDefaultValue(true).IsRequired(false);

        builder.HasMany(x => x.UserPets).WithMany(x => x.Pet).UsingEntity(typeof(UserPets));
    }
}