using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEscolar.Domain.Entities;
using System.Reflection.Emit;

namespace SistemaEscolar.Infrastructure.Persistence.Contexts.Configurations
{
    public class InstitutionEducationalLevelConfiguration : IEntityTypeConfiguration<InstitutionEducationalLevel>
    {
        public void Configure(EntityTypeBuilder<InstitutionEducationalLevel> builder)
        {
            builder.ToTable("InstitutionEducationalLevel");

        }
    }
}
