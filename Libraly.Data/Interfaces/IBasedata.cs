using Libraly.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Data.Interfaces
{
    public interface IBasedata<T> where T : class
    {
        void Create(T obj);
       IEnumerable<T> Read();
        void Update(T obj);
        void Delete(T obj);

        void Save();
    }
}
