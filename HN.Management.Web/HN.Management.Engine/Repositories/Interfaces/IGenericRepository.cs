using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
