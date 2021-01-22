using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Libraly.Logic.Interfaces
{
    public interface IData<T> where T:class
    {
        //CRUD -для бд
        void Creat(T obj);
        IQueryable<T> Read();
        void Update(T obj);
        void Delete(T obj);
    }
}
