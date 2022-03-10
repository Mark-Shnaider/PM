using PM.DAL.Domain;
using PM.DAL.Domain.Repositories;
using PM.DAL.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public EntityContext Context { get; }

        public UnitOfWork(EntityContext context)
        {
            Context = context;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _repositories.GetOrAdd(typeof(TEntity),
                x => new BaseRepository<TEntity>(Context)) as IBaseRepository<TEntity>;
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
