﻿using System;
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


        public IEventRepository Events => GetCustomRepository<IEventRepository>();
        public IRepository<EventType> EventTypes => GetEntityRepository<EventType>();
        public IRepository<Invoice> Invoices => GetEntityRepository<Invoice>();
        public IRepository<InvoiceRow> InvoiceRows => GetEntityRepository<InvoiceRow>();
        public ILocationRepository Locations => GetCustomRepository<ILocationRepository>();
        public IRepository<LocationType> LocationTypes => GetEntityRepository<LocationType>();
        public IRepository<PerformancePerformer> PerformancePerformers => GetEntityRepository<PerformancePerformer>();
        public IPerformanceRepository Performances => GetCustomRepository<IPerformanceRepository>();
        public IPerformerRepository Performers => GetCustomRepository<IPerformerRepository>();
        public IRepository<PerformerType> PerformerTypes => GetEntityRepository<PerformerType>();
        public IRepository<Ticket> Tickets => GetEntityRepository<Ticket>();
        public IRepository<TicketType> TicketTypes => GetEntityRepository<TicketType>();

        public IUserRepository Users => _UserRepository;

        

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

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
