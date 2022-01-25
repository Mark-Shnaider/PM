using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Domain.Repositories;

namespace PM.DAL.Domain
{
    public interface IUnitOfWork
    {
        public IBaseRepository<T> GetRepository<T>()
            where T : class;
        public void Commit();
        public Task CommitAsync();
    }
}
