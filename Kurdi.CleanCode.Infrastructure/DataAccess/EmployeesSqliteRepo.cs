using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Infrastructure.Data;

namespace Kurdi.CleanCode.Infrastructure.DataAccess
{
    public class EmployeesSqliteRepo : RepoBase<Employee> , IEmployeesRepo
    {
        public EmployeesSqliteRepo(AppDbContext db) : base(db)
        {

        }
    }
}
