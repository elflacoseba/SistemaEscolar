namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        IUserRepository Users { get; }
        IInstitutionRepository Institutions { get; }
        IEducationalLevelRepository EducationalLevels { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
