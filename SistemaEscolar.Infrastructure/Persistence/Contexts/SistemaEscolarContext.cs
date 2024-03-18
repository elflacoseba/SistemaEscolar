using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using System.Reflection;

namespace SistemaEscolar.Infrastructure.Persistence.Contexts
{
    public partial class SistemaEscolarContext : DbContext
    {
        public SistemaEscolarContext()
        {

        }

        public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Institution> Institutions { get; set; } = null!;
        public virtual DbSet<EducationalLevel> EducationalLevels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
