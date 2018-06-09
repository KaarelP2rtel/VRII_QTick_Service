using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories
{
    /// <summary>
    /// This is a class between Application entity framework and the entity framework itself.
    /// Any changes here will go upwards.
    /// </summary>
    /// <typeparam name="TEntity">Entity which will be used.</typeparam>
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;
        /// <summary>
        /// This is the constructor to set the database context and 
        /// select the database with which we wish to work with.
        /// </summary>
        /// <param name="dataContext">Database with which we want to work with.</param>
        public EFRepository(DbContext dataContext)
        {
            RepositoryDbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            RepositoryDbSet = dataContext.Set<TEntity>();
            if (RepositoryDbSet == null)
            {
                throw new ArgumentException("DBSet not found in dbcontext!");
            }
        }

        /// <summary>
        /// Used to get all of the given entities in the database.
        /// </summary>
        /// <returns>Returns all of the given entitys i n the database.</returns>
        public virtual IEnumerable<TEntity> All()
        {
            return RepositoryDbSet.ToList();
        }

        /// <summary>
        /// Used to get all of the given entities in the database with async method
        /// </summary>
        /// <returns>returns all of the given entities from the database</returns>
        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        /// <summary>
        /// Add an entity to the database.
        /// </summary>
        /// <param name="entity">entity which we want to add to the database.</param>
        public virtual void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        /// <summary>
        /// Adding an entity to the database with async method
        /// </summary>
        /// <param name="entity">Entity which we wish to add</param>
        /// <returns>returns nothing.</returns>
        public virtual async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        /// <summary>
        /// Used to update an entity in the repository
        /// </summary>
        /// <param name="entity">entity which we wish to update</param>
        /// <returns>The updated entity.</returns>
        public virtual TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        /// <summary>
        /// Used to remove an entity from the database by giving the entity
        /// </summary>
        /// <param name="entity">Entity which we wish to remove from database</param>
        public virtual void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        /// <summary>
        /// Used to remove an entity from the database by giving the id
        /// </summary>
        /// <param name="id">Entity which we wish to remove from database</param>
        public virtual void Remove(params object[] id)
        {
            var e = Find(id);
            if (e == null) throw new DBConcurrencyException();
            RepositoryDbSet.Remove(e);
            
        }

        /// <summary>
        /// Used to control an entity exists in database by giving the entity
        /// </summary>
        /// <param name="entity">Entity which exist we control</param>
        /// <returns>Boolean of exist</returns>
        public virtual bool Exists(TEntity entity)
        {
            return RepositoryDbSet.Any(e => e == entity);
        }
    }
}
