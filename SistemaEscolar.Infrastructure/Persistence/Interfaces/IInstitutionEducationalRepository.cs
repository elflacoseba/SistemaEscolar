using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IInstitutionEducationalRepository
    {
        Task<bool> CreateInstitutionEducationalLevelAsync(Institution institution, EducationalLevel educationalLevel);
    }
}
