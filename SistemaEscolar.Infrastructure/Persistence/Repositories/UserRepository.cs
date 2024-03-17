using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {   
        private readonly SistemaEscolarContext _context;

        public UserRepository(SistemaEscolarContext context ) : base(context)
        {
            _context = context;
        }

        public async Task<User> AccountByEmail(string email)
        {
            var account = await _context.Users.FirstOrDefaultAsync(x => x.Email!.Equals(email));

            return account!;
        }

        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users.FirstOrDefaultAsync(x => x.UserName!.Equals(userName));
            
            return account!;
        }
    }
}
