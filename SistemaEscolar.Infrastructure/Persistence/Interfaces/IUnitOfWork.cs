namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        IUserRepository Users { get; }
        IInstitutionRepository Institutions { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
