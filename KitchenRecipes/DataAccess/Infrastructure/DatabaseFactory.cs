using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Context;

namespace DataAccess.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private KitchenContext _dataContext;
    public KitchenContext Get()
    {
        return _dataContext ?? (_dataContext = new KitchenContext());
    }
    protected override void DisposeCore()
    {
        if (_dataContext != null)
            _dataContext.Dispose();
    }
}
}
