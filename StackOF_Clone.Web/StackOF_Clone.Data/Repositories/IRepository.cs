using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Data.Repositories
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        IList<T> GetAll();
        Task<T> GetByIdAsync(int id);
        IList<T> Get(Expression<Func<T, bool>> predicate = null);
        int GetCount(Expression<Func<T, bool>> predicate = null);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
