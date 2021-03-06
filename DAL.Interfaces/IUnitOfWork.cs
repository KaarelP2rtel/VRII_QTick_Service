﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces
{
    /// <summary>
    /// This interface used by IAppUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();

        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        TRepositoryInterface GetCustomRepository<TRepositoryInterface>() where TRepositoryInterface : class;

    }
}
