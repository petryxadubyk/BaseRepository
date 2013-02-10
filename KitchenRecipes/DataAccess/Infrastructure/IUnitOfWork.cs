using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
