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
    public class EFRepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, Func<IDataContext, object>> _customRepositoryFactories
            = GetCustomRepoFactories();

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

        public Func<IDataContext, object> GetCustomRepositoryFactory<TRepoInterface>() where TRepoInterface : class
        {
            _customRepositoryFactories.TryGetValue(
                typeof(TRepoInterface), 
                out Func<IDataContext, object> factory
            );
            return factory;
        }

        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {

            return (dataContext) => new EFRepository<TEntity>(dataContext as ApplicationDbContext);
        }
    }
}
