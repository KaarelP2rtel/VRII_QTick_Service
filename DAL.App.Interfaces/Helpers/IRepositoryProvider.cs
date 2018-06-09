using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces.Repositories;

namespace DAL.App.Interfaces.Helpers
{
    /// <summary>
    /// This is used for getting the repositories.
    /// </summary>
    public interface IRepositoryProvider
    {
        // With this we give back the IRepository which holds all the control over a repository. 
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;

        TRepository GetCustomRepository<TRepository>() where TRepository : class;
       
    }
}
