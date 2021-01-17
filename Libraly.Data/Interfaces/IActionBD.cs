using Libraly.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Data.Interfaces
{
    public interface IActionBD<T> where T:class 
    {
        //ST-SomeThing
        public IEnumerable<T> GetAllDates();
        public Task<T> Find(string Id);
        public void Add(T ST);
        public void Delete(T ST);
        public void Update(T ST);
        public void SaveChanges();
    }
}
