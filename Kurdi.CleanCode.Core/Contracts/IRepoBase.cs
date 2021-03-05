using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kurdi.CleanCode.Core.Contracts
{
    public interface IRepoBase<T>
    {
        IQueryable<T> FindAll(int pageSize, int pageNumber);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int pageSize, int pageNumber);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
