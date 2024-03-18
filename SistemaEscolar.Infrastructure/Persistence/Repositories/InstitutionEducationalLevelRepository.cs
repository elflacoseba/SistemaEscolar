using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class InstitutionEducationalLevelRepository : IInstitutionEducationalRepository
    {
        private readonly SistemaEscolarContext _context;

        public InstitutionEducationalLevelRepository(SistemaEscolarContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateInstitutionEducationalLevelAsync(Institution institution, EducationalLevel educationalLevel)
        {
            var institutionEducationalLevel = new InstitutionEducationalLevel
            {
                InstitutionId = institution.Id,
                Institution = null,
                EducationalLevelId = educationalLevel.Id,
                EducationalLevel = null
            };

            await _context.InstitutionEducationalLevels.AddAsync(institutionEducationalLevel);

            var recordAffected = await _context.SaveChangesAsync();

            return recordAffected > 0;
        }
    }
}
