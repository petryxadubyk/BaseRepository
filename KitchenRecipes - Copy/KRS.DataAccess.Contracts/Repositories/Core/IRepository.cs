using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KRS.DataAccess.Contracts.Repositories.Core
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> where);
        T GetById(long id);
        IQueryable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Delete(Expression<Func<T, bool>> where);    
    }
}
