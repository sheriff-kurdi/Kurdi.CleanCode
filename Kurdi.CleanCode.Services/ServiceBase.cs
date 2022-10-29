using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kurdi.CleanCode.Services
{
    public class ServiceBase <T> : IServiceBase<T>
    {
        private readonly IRepoBase<T> _repo;

        public ServiceBase(IRepoBase<T> repo)
        {
            this._repo = repo;
        }
        public void Create(T entity)
        {
            _repo.Create(entity);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public IQueryable<T> FindAll(int pageSize, int pageNumber)
        {
            return _repo.FindAll(pageSize,pageNumber);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int pageSize, int pageNumber)
        {
            return _repo.FindByCondition(expression, pageSize, pageNumber);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repo.FindByCondition(expression);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }
    }
}
