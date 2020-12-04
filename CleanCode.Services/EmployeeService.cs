using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeesRepo employeesRepo;

        public EmployeeService(IEmployeesRepo employeesRepo)
        {
            this.employeesRepo = employeesRepo;
        }
        public  void Create(Employee employee)
        {
            employeesRepo.Create(employee);
        }

        public void Delete(Employee employee)
        {
            employeesRepo.Delete(employee);
        }

        public List<Employee> GetAll()
        {
            return employeesRepo.GetAll();
        }

        public  Employee GetById(int id)
        {
            return employeesRepo.GetById(id);
        }

        public List<Employee> GetWhere(Expression<Func<Employee, bool>> expression)
        {
            return employeesRepo.GetWhere(expression);
        }

        public void Update(Employee newEmployee)
        {
            employeesRepo.Update(newEmployee);
        }
    }
}
