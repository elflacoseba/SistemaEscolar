using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Domain.Entities;
using System.Reflection.Emit;

namespace SistemaEscolar.Infrastructure.Persistence.Contexts.Configurations
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired()
                .IsUnicode(false);
            builder.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.AuditCreateDate)
                .HasColumnType("datetime");
            builder.Property(e => e.AuditUpdateDate)
                .HasColumnType("datetime");
            builder.HasOne<User>(i => i.User)
                .WithMany(u => u.Institutions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(I => I.EducationalLevels)
                .WithMany(N => N.Institutions)
                .UsingEntity<InstitutionEducationalLevel>
                (
                ie => ie.HasOne(prop => prop.EducationalLevel)
                .WithMany()
                .HasForeignKey(prop => prop.EducationalLevelId),
                ie => ie.HasOne(prop => prop.Institution)
                .WithMany()
                .HasForeignKey(prop => prop.InstitutionId),
                ie =>
                {
                    ie.HasKey(prop => new { prop.InstitutionId, prop.EducationalLevelId });
                }

                );


        }
    }
}
