using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class InstitutionRepository : GenericRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(SistemaEscolarContext context) : base(context)
        {
            
        }
    }
}
