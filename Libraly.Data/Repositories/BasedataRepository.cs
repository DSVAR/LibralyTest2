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
        public async Task Create(T obj)
        {
           await _context.AddAsync(obj);
        }

        public void Delete(T obj)
        {
            _context.Remove<T>(obj);
        }

        public IQueryable<T> Read()
        {
            var items = dbSet.AsQueryable();
            var i = _context.FindAsync<T>();
            return items;
        }

   

        public void Update(T obj)
        {
            _context.Update(obj);
        }
    }
}
