using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Infrastructure.Persistence.Contexts.Configurations
{
    public class EducationalLevelConfiguration : IEntityTypeConfiguration<EducationalLevel>
    {
        public void Configure(EntityTypeBuilder<EducationalLevel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .IsRequired()
                .IsUnicode(false);
            builder.Property(e => e.AuditCreateDate)
               .HasColumnType("datetime");
            builder.Property(e => e.AuditUpdateDate)
                .HasColumnType("datetime");

            //var educationalLevels = new[]
            //{
            //    new EducationalLevel { Id = 1, Name = "Inicial", AuditCreateUser = 1, AuditCreateDate = DateTime.UtcNow },
            //    new EducationalLevel { Id = 2, Name = "Primario", AuditCreateUser = 1, AuditCreateDate = DateTime.UtcNow },
            //    new EducationalLevel { Id = 3, Name = "Secundario", AuditCreateUser = 1, AuditCreateDate = DateTime.UtcNow },
            //    new EducationalLevel { Id = 4, Name = "Superior", AuditCreateUser = 1, AuditCreateDate = DateTime.UtcNow },
            //};

            //builder.HasData(educationalLevels);

        }
    }
}
