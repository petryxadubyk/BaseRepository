using System;
using KRS.DataAccess.DataContext;

namespace KRS.DataAccess.IInfrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        KRSContext Get();
    }
}
