using Libraly.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationContext Context{ get; }

        void Save();
    }
}
