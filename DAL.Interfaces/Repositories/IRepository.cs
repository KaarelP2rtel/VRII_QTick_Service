using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();
        Task<IEnumerable<TEntity>> AllAsync();


        TEntity Find(params object[] id);
        Task<TEntity> FindAsync(params object[] id);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);
        void Remove(params object[] id);

    }
}
