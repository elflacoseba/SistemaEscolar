using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Domain.Entities;

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

            builder.HasOne<User>(i => i.User)
                .WithMany(u => u.Institutions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
