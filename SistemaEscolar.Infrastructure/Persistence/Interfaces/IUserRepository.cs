using SistemaEscolar.Domain.Entities;

namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AccountByUserName(string userName);
    }
}
