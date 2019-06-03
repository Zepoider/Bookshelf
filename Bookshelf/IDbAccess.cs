using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf
{
    public interface IDbAccess<T>
    {
        IEnumerable<T> All();
        Task<T> GetByIdAsync(Guid id);
        Task<Guid> InsertAsync(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
