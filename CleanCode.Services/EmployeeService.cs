using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using CleanCode.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Services
{
    public class EmployeeService : ServiceBase<Employee> , IEmployeeService 
    {

        public EmployeeService(IRepoBase<Employee> repo) : base(repo)
        {
            
        }

    }
}
