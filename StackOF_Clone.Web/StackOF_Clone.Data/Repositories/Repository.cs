using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Data.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _session.SaveAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _session.UpdateAsync(entity);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            await DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return (await _session.GetAsync<T>(id));
        }

        public virtual IList<T> GetAll()
        {
            return _session.Query<T>().ToList();
        }

        public virtual int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            var count = _session.Query<T>()
                .Where(predicate)
                .Count();

            return count;
        }

        public virtual IList<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            var list = _session.Query<T>()
                .Where(predicate)
                .ToList();

            return list;
        }
    }
}
