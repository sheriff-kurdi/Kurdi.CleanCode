using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using CleanCode.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.DataAccess
{
    public class EmployeesSqliteRepo : IEmployeesRepo
    {
        private readonly AppDbContext db;

        public EmployeesSqliteRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void  Create(Employee employee)
        {
            db.employees.Add(employee);
            db.SaveChanges();

        }

        public void Delete(Employee employee)
        {
            db.employees.Remove(employee);
            db.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return  db.employees.ToList();
        }

        public Employee GetById(int id)
        {       
            return  db.employees.Find(id);
        }

        public  List<Employee> GetWhere(Expression<Func<Employee, bool>> expression)
        {
            return  db.employees.Where(expression).ToList();
        }

        public void Update(Employee newEmployee)
        {
            db.employees.Update(newEmployee);
            db.SaveChanges();
        }
    }
}
