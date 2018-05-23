using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EFPersonRepository : EFRepository<Person>, IPersonRepository
    {
        public EFPersonRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.PersonId == id);
        }

        public override Person Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(x => x.Contacts)
                    .ThenInclude(type => type.ContactType)
                .SingleOrDefault(x => (int)id[0] == x.PersonId);
        }
    }
}
