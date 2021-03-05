using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kurdi.CleanCode.Infrastructure.DataAccess
{
    public class EmployeesSqliteRepo : RepoBase<Employee> , IEmployeesRepo
    {
        public EmployeesSqliteRepo(AppDbContext db) : base(db)
        {

        }
    }
}
