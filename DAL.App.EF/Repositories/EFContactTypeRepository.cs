using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EFContactTypeRepository : EFRepository<ContactType>, IContactTypeRepository
    {
        public EFContactTypeRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
