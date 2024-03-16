namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {        
        IUserRepository Users { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
