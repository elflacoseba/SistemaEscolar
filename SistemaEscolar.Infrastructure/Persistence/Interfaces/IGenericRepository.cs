using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Infrastructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace SistemaEscolar.Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(int id);

        IQueryable<T> GetEntityQuery( Expression<Func<T, bool>>? filter = null );

        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
        
    }
}
