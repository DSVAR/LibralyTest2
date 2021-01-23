using Libraly.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Data.Interfaces
{
    public interface IBasedata<T> where T : class
    {
        void Create(T obj);
        IQueryable<T> Read();
        void Update(T obj);
        void Delete(T obj);

    }
}
