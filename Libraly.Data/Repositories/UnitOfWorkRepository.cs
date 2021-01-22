using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public ApplicationContext context { get;  }


        public UnitOfWorkRepository(ApplicationContext Context)
        {
            context = Context;
        }


        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
