using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Data.Repositories
{
    public class BasedataRepository<T> : IBasedata<T> where T : class
    {
        private readonly ApplicationContext _context;
        internal DbSet<T> dbSet;

        public BasedataRepository(ApplicationContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public void Create(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public IQueryable<T> Read()
        {
            var items= dbSet.AsQueryable<T>();
            return items;
        }

   

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
