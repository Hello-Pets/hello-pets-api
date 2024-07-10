using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        // builder.HasKey(x => x.Id);

        // builder.OwnsOne(x => x.Nickname).Property(x => x.Name).HasColumnType("NVARCHAR").HasMaxLength(99).HasColumnName("FirstName").IsRequired();

        // builder.Property(x => x.Photo).HasColumnName("ProfilePicture").HasMaxLength(255).IsRequired(false);

        // builder.OwnsOne(x => x.Document).Property(x => x.Type).HasColumnName("DocumentType").IsRequired();

        // builder.OwnsOne(x => x.Document).Property(x => x.Number).HasColumnName("DocumentNumber").IsRequired();

        // builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired();

        // builder.OwnsOne(x => x.PreferencesAndDislikes).Property(x => x.Preferences).HasColumnName("Preferences").IsRequired();

        // builder.OwnsOne(x => x.PreferencesAndDislikes).Property(x => x.Dislikes).HasColumnName("Dislikes").IsRequired();

        // builder.OwnsOne(x => x.Specie).Property(x => x.PetSpecie).HasColumnName("Specie").IsRequired();

        // builder.OwnsOne(x => x.Specie).Property(x => x.Breed).HasColumnName("Breed").IsRequired();

        // builder.OwnsOne(x => x.MiniBio).Property(x => x.Description).HasColumnName("MiniBio").HasMaxLength(100).IsRequired();

        // builder.Property(x => x.PetsCoats).HasColumnName("Coat").IsRequired();

        // builder.OwnsOne(x => x.BodyMetrics).Property(x => x.Height).HasColumnName("Height").IsRequired();

        // builder.OwnsOne(x => x.BodyMetrics).Property(x => x.Weight).HasColumnName("Weight").IsRequired();

        // builder.OwnsOne(x => x.BodyMetrics).Property(x => x.Length).HasColumnName("Length").IsRequired();

        // builder.Property(x => x.Personality).HasColumnName("Personality").IsRequired();

        // builder.Property(x => x.Neutered).HasColumnName("Neutered").IsRequired();

        // builder.Property(x => x.HasMicrochip).HasColumnName("Microchip").IsRequired();

        // builder.Property(x => x.SpecialNeeds).HasColumnName("SpecialNeeds").IsRequired();
    }
}