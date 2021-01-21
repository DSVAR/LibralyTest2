using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Repositories
{
    class UnitOfWorkRepository : IUnitOfWork
    {
        public ApplicationContext Context { get;  }


        public UnitOfWorkRepository(ApplicationContext context)
        {
            Context = context;
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
