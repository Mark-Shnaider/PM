using Microsoft.EntityFrameworkCore;
using PM.DAL.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        readonly EntityContext _context;
        readonly DbSet<TEntity> _dbSet;
        public BaseRepository(EntityContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            var entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
                entityEntry.State = EntityState.Added;
            else
                _dbSet.Add(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            var entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(Delete);
        }

        public void DeleteById(Guid Id)
        {
            var entity = GetById(Id);
            if (entity == null)
                return;

            Delete(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            var entityEntry = _context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
                _context.Attach(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
