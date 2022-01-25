using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Domain.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        public T GetById(Guid Id);
        public Task<T> GetByIdAsync();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteById(Guid Id);
        public void Delete(IEnumerable<T> entities);
        public void Commit();
        public Task CommitAsync();
    }
}
