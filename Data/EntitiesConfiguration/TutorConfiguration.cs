using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloPets.Data.EntitiesConfiguration;

public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
{
    public void Configure(EntityTypeBuilder<Tutor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name).Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(99).HasColumnName("FirstName").IsRequired();

        builder.OwnsOne(x => x.Name).Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(99).HasColumnName("LastName").IsRequired();

        builder.OwnsOne(x => x.Email).Property(x => x.Address).HasColumnName("Email").IsRequired();

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.Code).HasColumnName("EmailVerificationCode").IsRequired();

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.ExpireAt).HasColumnName("EmailVerificationExpiresAt").IsRequired(false);

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Property(x => x.VerifiedAt).HasColumnName("EmailVerificationVerifiedAt").IsRequired(false);

        builder.OwnsOne(x => x.Email).OwnsOne(x => x.Verification).Ignore(x => x.IsActive);

        builder.OwnsOne(x => x.Password).Property(x => x.Hash).HasColumnName("PasswordHash").IsRequired();

        builder.OwnsOne(x => x.Document).Property(x => x.Type).HasColumnName("DocumentType").IsRequired(false);

        builder.OwnsOne(x => x.Document).Property(x => x.Number).HasColumnName("DocumentNumber").IsRequired(false);

        builder.Property(x => x.BirthDate).HasColumnName("BirthDate").IsRequired(false);

        builder.OwnsOne(x => x.Address).Property(x => x.Country).HasColumnName("Contry").IsRequired(false);

        builder.OwnsOne(x => x.Address).Property(x => x.State).HasColumnName("State").IsRequired(false);

        builder.OwnsOne(x => x.Address).Property(x => x.City).HasColumnName("City").IsRequired(false);

        builder.OwnsOne(x => x.Address).Property(x => x.Street).HasColumnName("Street").IsRequired(false);

        builder.OwnsOne(x => x.Address).Property(x => x.PostalCode).HasColumnName("PostalCode").IsRequired(false);

        builder.Property(x => x.Photo).HasColumnName("ProfilePicture").HasMaxLength(255).IsRequired(false);

        builder.OwnsOne(x => x.MiniBio).Property(x => x.Description).HasMaxLength(100).IsRequired(false);

        builder.OwnsOne(x => x.Phone).Property(x => x.CountryPhoneCode).HasMaxLength(3).IsRequired(false);

        builder.OwnsOne(x => x.Phone).Property(x => x.LocalPhoneCode).HasMaxLength(3).IsRequired(false);

        builder.OwnsOne(x => x.Phone).Property(x => x.Number).HasMaxLength(10).IsRequired(false);

        builder.HasMany(x => x.Pets).WithOne(x => x.Tutor).HasForeignKey(x => x.TutorId);
    }
}