using Libraly.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationContext context { get; }
        void Save();
    }
}
