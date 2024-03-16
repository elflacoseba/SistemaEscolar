using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {        
        public UserRepository(SistemaEscolarContext context ) : base(context) { }
    }
}
