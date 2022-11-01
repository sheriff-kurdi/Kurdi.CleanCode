using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kurdi.CleanCode.Services
{
    public class EmployeeService : ServiceBase<Employee> , IEmployeeService 
    {

        public EmployeeService(IRepoBase<Employee> repo) : base(repo)
        {
            
        }

    }
}
