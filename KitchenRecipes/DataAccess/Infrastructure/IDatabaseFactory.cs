using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Context;

namespace DataAccess.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        KitchenContext Get();
    }
}
