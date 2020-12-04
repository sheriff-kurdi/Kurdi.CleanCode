using CleanCode.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Core.Contracts
{
    public interface IEmployeesRepo
    {
        void Create(Employee employee);
        void Delete(Employee employee);
        void Update(Employee newEmployee);
        List<Employee> GetAll();
        Employee GetById(int id);
        List<Employee> GetWhere(Expression<Func<Employee, bool>> expression);
    }
}
