using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;

namespace DAL.App.Interfaces.Helpers
{
    /// <summary>
    /// This interface is used to get the requiredRepositorys
    /// </summary>
    public interface IRepositoryFactory
    {
        Func<IDataContext, object> GetCustomRepositoryFactory<TRepoInterface>() where TRepoInterface : class;

        Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class;

    }
}
