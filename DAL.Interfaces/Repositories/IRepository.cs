using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    /// <summary>
    /// This interface holds all of the ways that EntityFramework should be contacted 
    /// by this application
    /// </summary>
    /// <typeparam name="TEntity">TEntity is the entity which we want to work with</typeparam>
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

        bool Exists(TEntity entity);

    }
}
