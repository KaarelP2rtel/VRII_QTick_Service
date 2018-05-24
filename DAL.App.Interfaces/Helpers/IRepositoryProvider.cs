﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces.Repositories;

namespace DAL.App.Interfaces.Helpers
{
    public interface IRepositoryProvider
    {
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        TRepository GetCustomRepository<TRepository>() where TRepository : class;
       
    }
}
