using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.EF
{
    /// <summary>
    /// This class is used to do work with the database. 
    /// </summary>
    public class AppEFUnitOfWork : IAppUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IUserRepository _userRepository;

        public AppEFUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider, IUserRepository userRepository)
        {
            _repositoryProvider = repositoryProvider;
            _userRepository = userRepository;
            _applicationDbContext = dataContext as ApplicationDbContext;
            if (_applicationDbContext == null)
            {
                throw new NullReferenceException("No EF dbcontext found in UOW");
            }
        }

        /// <summary>
        /// Here are all of the Repositories which we will edit and use to edit information in database. 
        /// To add and edit a domain to database it must be added here also.
        /// </summary>
        public IEventRepository Events => GetCustomRepository<IEventRepository>();
        public IRepository<EventType> EventTypes => GetEntityRepository<EventType>();
        public IInvoiceRepository Invoices => GetCustomRepository<IInvoiceRepository>();
        public IRepository<InvoiceRow> InvoiceRows => GetEntityRepository<InvoiceRow>();
        public ILocationRepository Locations => GetCustomRepository<ILocationRepository>();
        public IRepository<LocationType> LocationTypes => GetEntityRepository<LocationType>();
        public IPerformancePerformerRepository PerformancePerformers => GetCustomRepository<IPerformancePerformerRepository>();
        public IPerformanceRepository Performances => GetCustomRepository<IPerformanceRepository>();
        public IPerformerRepository Performers => GetCustomRepository<IPerformerRepository>();
        public IRepository<PerformerType> PerformerTypes => GetEntityRepository<PerformerType>();
        public ITicketRepository Tickets => GetCustomRepository<ITicketRepository>();
        public IRepository<TicketType> TicketTypes => GetEntityRepository<TicketType>();

        public IUserRepository Users => _userRepository;


        /// <summary>
        /// This must be added here because controllers will be using unitofwork and they need a way to save. 
        /// This is used to save changes in the database after making changes. 
        /// </summary>
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        /// <summary>
        /// This is used to save changes (async) in the database after making changes. 
        /// </summary>
        /// <returns>Returns nothing</returns>
        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetEntityRepository<TEntity>();
        }

        public TRepositoryInterface GetCustomRepository<TRepositoryInterface>() where TRepositoryInterface : class
        {
            return _repositoryProvider.GetCustomRepository<TRepositoryInterface>();
        }



    }
}
