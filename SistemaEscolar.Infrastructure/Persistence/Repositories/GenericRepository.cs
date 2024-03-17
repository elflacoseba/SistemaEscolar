using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Commons.Bases.Request;
using SistemaEscolar.Infrastructure.Helpers;
using SistemaEscolar.Infrastructure.Persistence.Contexts;
using SistemaEscolar.Infrastructure.Persistence.Interfaces;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using SistemaEscolar.Utilities.Static;

namespace SistemaEscolar.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SistemaEscolarContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(SistemaEscolarContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .AsNoTracking().ToListAsync();

            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return getById!;
        }
        
        public async Task<bool> AddAsync(T entity)
        {
            entity.AuditCreateUser = 1;
            entity.AuditCreateDate = DateTime.UtcNow;            

            await _context.AddAsync(entity);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            entity.AuditUpdateUser = 1;
            entity.AuditUpdateDate = DateTime.UtcNow;

            _context.Update(entity);

            _context.Entry(entity).Property(x => x.AuditCreateUser).IsModified = false;
            _context.Entry(entity).Property(x => x.AuditCreateDate).IsModified = false;

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            _context.Remove(entity);

            var recordAffected = await _context.SaveChangesAsync();
            return recordAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }

    }
}
