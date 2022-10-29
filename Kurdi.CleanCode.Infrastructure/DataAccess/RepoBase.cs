using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kurdi.CleanCode.Infrastructure.DataAccess
{
    public class RepoBase<T> : IRepoBase<T> where T : class
    {
        private readonly AppDbContext _db;

        public RepoBase(AppDbContext db)
        {
            this._db = db;
        }
        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            this._db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IQueryable<T> FindAll(int pageSize, int pageNumber)
        {
            return this._db.Set<T>()
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, int pageSize, int pageNumber)
        {
            return this._db.Set<T>().Where(expression)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._db.Set<T>().Where(expression).AsNoTracking();
        }



        public void Update(T entity)
        {
            this._db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}
