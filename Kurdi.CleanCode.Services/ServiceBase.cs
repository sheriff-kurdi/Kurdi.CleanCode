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
        private readonly IRepoBase<T> repo;

        public ServiceBase(IRepoBase<T> repo)
        {
            this.repo = repo;
        }
        public void Create(T entity)
        {
            repo.Create(entity);
        }

        public void Delete(T entity)
        {
            repo.Delete(entity);
        }

        public IQueryable<T> FindAll(int pageSize, int pageNumber)
        {
            return repo.FindAll(pageSize,pageNumber);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int pageSize, int pageNumber)
        {
            return repo.FindByCondition(expression, pageSize, pageNumber);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return repo.FindByCondition(expression);
        }

        public void Update(T entity)
        {
            repo.Update(entity);
        }
    }
}
