using KRS.DataAccess.DataContext;
using KRS.DataAccess.IInfrastructure;

namespace KRS.DataAccess.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private KRSContext _dataContext;
    public KRSContext Get()
    {
        return _dataContext ?? (_dataContext = new KRSContext());
    }
    protected override void DisposeCore()
    {
        if (_dataContext != null)
            _dataContext.Dispose();
    }
}
}
