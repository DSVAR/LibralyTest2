using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Data.Services
{
    class BasedataRepository<T> : IBasedata<T> where T : class
    {
        private readonly ApplicationContext _context;
        internal DbSet<T> dbSet;

        public BasedataRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(T obj)
        {
            _context.Add(obj);
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
        }

        public IEnumerable<T> Read()
        {
            var list = dbSet;
            return list;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
