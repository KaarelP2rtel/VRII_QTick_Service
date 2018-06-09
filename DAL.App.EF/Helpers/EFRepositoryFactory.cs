using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    /// <summary>
    /// This class is used to get the acces to the repositories
    /// </summary>
    public class EFRepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// This is used to hold all of the DatabaseContexts. 
        /// </summary>
        private readonly Dictionary<Type, Func<IDataContext, object>> _customRepositoryFactories
            = GetCustomRepoFactories();

        /// <summary>
        /// Used to create the dictionary of all the databasecontexts.
        /// </summary>
        /// <returns>Dictionary which contains all of the databaseContexts.</returns>
        private static Dictionary<Type, Func<IDataContext, object>> GetCustomRepoFactories()
        {
            return new Dictionary<Type, Func<IDataContext, object>>()
            {
               
                {typeof(IEventRepository), (dataContext) => new EFEventRepository(dataContext as ApplicationDbContext) },
                {typeof(IEventTypeRepository), (dataContext) => new EFEventTypeRepository(dataContext as ApplicationDbContext) },
                {typeof(IInvoiceRowRepository), (dataContext) => new EFInvoiceRepository(dataContext as ApplicationDbContext) },
                {typeof(IInvoiceRepository), (dataContext) => new EFInvoiceRepository(dataContext as ApplicationDbContext) },
                {typeof(ILocationRepository), (dataContext) => new EFLocationRepository(dataContext as ApplicationDbContext) },
                {typeof(ILocationTypeRepository), (dataContext) => new EFLocationTypeRepository(dataContext as ApplicationDbContext) },
                {typeof(IPerformancePerformerRepository), (dataContext) => new EFPerformancePerformerRepository(dataContext as ApplicationDbContext) },
                {typeof(IPerformanceRepository), (dataContext) => new EFPerformanceRepository(dataContext as ApplicationDbContext) },
                {typeof(IPerformerRepository), (dataContext) => new EFPerformerRepository(dataContext as ApplicationDbContext) },
                {typeof(IPerformerTypeRepository), (dataContext) => new EFPerformerTypeRepository(dataContext as ApplicationDbContext) },
                {typeof(ITicketTypeRepository), (dataContext) => new EFTicketTypeRepository(dataContext as ApplicationDbContext) },
                {typeof(ITicketRepository), (dataContext) => new EFTicketRepository(dataContext as ApplicationDbContext) },
                
            };
        }

        /// <summary>
        /// Here we try to get a Repository which we have created and added to the dictionary before.
        /// </summary>
        /// <typeparam name="TRepoInterface">Repository which we try to get</typeparam>
        /// <returns>The custom repository we're searching for</returns>
        public Func<IDataContext, object> GetCustomRepositoryFactory<TRepoInterface>() where TRepoInterface : class
        {
            _customRepositoryFactories.TryGetValue(
                typeof(TRepoInterface), 
                out Func<IDataContext, object> factory
            );
            return factory;
        }
        /// <summary>
        /// This gets the standard repository and returns it 
        /// </summary>
        /// <typeparam name="TEntity">Repository we're searching for</typeparam>
        /// <returns>the databasecontext we're looking for</returns>
        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            // We use this return method to return datacontext as ApplicationDbContext
            // Essentially I guess we could use - return new EFRepository<EFRepository<TEntity>() however we need to use the "as ApplicationDbContext" on next line.
            return (dataContext) => new EFRepository<TEntity>(dataContext as ApplicationDbContext);
        }
    }
}
