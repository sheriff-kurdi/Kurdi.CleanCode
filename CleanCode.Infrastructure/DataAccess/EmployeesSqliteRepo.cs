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
    public class EmployeesSqliteRepo : RepoBase<Employee> , IEmployeesRepo
    {
        public EmployeesSqliteRepo(AppDbContext db) : base(db)
        {

        }
    }
}
