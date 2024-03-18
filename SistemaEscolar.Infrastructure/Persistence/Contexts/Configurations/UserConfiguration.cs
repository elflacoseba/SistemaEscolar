using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Infrastructure.Persistence.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Image)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
            builder.Property(e => e.AuditCreateDate)
                .HasColumnType("datetime");
            builder.Property(e => e.AuditUpdateDate)
                .HasColumnType("datetime");            
        }
    }
}
