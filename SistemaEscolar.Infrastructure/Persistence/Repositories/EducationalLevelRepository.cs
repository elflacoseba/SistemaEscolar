using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class EducationalLevelRepository : GenericRepository<EducationalLevel>, IEducationalLevelRepository
    {
        public EducationalLevelRepository(SistemaEscolarContext context) : base(context)
        {
        }
    }
}
