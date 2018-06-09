using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;

namespace DAL.App.EF.Helpers
{
    /// <summary>
    /// This class provides all of the repositories we use.
    /// </summary>
    public class EFRepositoryProvider : IRepositoryProvider
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepositoryFactory _repositoryFactory;

        // here we keep our already created repos!
        private readonly  Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();

        public EFRepositoryProvider(IDataContext dataContext, IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _applicationDbContext = dataContext as ApplicationDbContext;
            if (_applicationDbContext == null)
            {
                throw new NullReferenceException("No EF dbcontext found in UOW");
            }
        }

        /// <summary>
        /// This method is used to get the repositories which we haven't created for this application.
        /// </summary>
        /// <typeparam name="TEntity">Repository we wish to retrieve.</typeparam>
        /// <returns>The repository we are looking for.</returns>
        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return GetOrMakeRepository<IRepository<TEntity>>
                (_repositoryFactory.GetStandardRepositoryFactory<TEntity>());

        }

        /// <summary>
        /// Here we make the repository we wish to get or ge get it from the cache.
        /// </summary>
        /// <typeparam name="TRepository">Repository we are searching for</typeparam>
        /// <param name="factory">factory used to get the repositories</param>
        /// <returns>Repository we are looking for.</returns>
        private TRepository GetOrMakeRepository<TRepository>(Func<IDataContext, object> factory) 
            where TRepository : class  {

            // Here we check if the repository already exists in the Dictionary and if it does we return it.
            if (_repositoryCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository)repo;
            }

            // If the repository is in the dictionary but for some reason is null then we can't find give it back
            if (factory == null)
            {
                throw new ArgumentNullException($"No factory found for type {typeof(TRepository).Name}");
            }

            // We get here if the repository wasnt found in the Dictionary. In that case we make it ourself
            repo = factory(_applicationDbContext);

            // WE add the repository to the cache so if we need it the next time we have it. 
            _repositoryCache.Add(typeof(TRepository), repo);

            return (TRepository) repo;

        }

        /// <summary>
        /// Used to get the repository we wish to retrieve.
        /// To use this method you have to previously specify the repository you are currently searching for.
        /// </summary>
        /// <typeparam name="TRepository">Repository which we wish to retrieve and we ahve prieviously specified.</typeparam>
        /// <returns>Repository which we wish to retrieve</returns>
        public TRepository GetCustomRepository<TRepository>() 
            where TRepository : class
        {
            return GetOrMakeRepository<TRepository>(
                _repositoryFactory.GetCustomRepositoryFactory<TRepository>());
        }

       
    }
}
