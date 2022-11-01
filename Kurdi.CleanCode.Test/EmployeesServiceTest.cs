using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Core.Entities;
using Kurdi.CleanCode.Services;
using Kurdi.CleanCode.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kurdi.CleanCode.Test
{
    public class EmployeesServiceTest
    {

        Mock<IEmployeesRepo> _employeesRepoMoc;
        IEmployeeService _employeesService;
        IQueryable<Employee> _employeesQuery;
        List<Employee> _employees = new List<Employee>()
        {
            new Employee(){Id = 1, Department="IT", Name= "sheriff", Salary = 10},
            new Employee(){Id = 2, Department="acc", Name= "maher", Salary = 5},
            new Employee(){Id = 3, Department="finance", Name= "mohsen", Salary = 8},


        };
        
        public EmployeesServiceTest()
        {
            _employeesRepoMoc = new Mock<IEmployeesRepo>();
            _employeesService = new EmployeeService(_employeesRepoMoc.Object);
            _employeesQuery  = _employees.AsQueryable();

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(22)]

        public void GetByIdTest(int employeeId)
        {
            //prepration
            _employeesRepoMoc.Setup(x => x.FindByCondition( e => e.Id == employeeId))
                .Returns(_employeesQuery.Where(e => e.Id == employeeId));
            var expectedValue = _employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId);

            //Acction
            var actualValue = _employeesService.FindByCondition(e => e.Id == employeeId);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void FindAllTest()
        {
            //prepration
            _employeesRepoMoc.Setup(x => x.FindAll(9, 1)).Returns(_employeesQuery);
            IQueryable<Employee> expectedValue = _employeesRepoMoc.Object.FindAll(9, 1);

            //Acction
            IQueryable<Employee> actualValue = _employeesService.FindAll(9, 1);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(22)]
        public void FindByIdTest(int employeeId)
        {
            //prepration
            _employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Id == employeeId))
                .Returns(_employeesQuery.Where(e => e.Id == employeeId));
            IQueryable<Employee> expectedValue = _employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId);

            //Acction
            IQueryable<Employee> actualValue = _employeesService.FindByCondition(e => e.Id == employeeId);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }


        [Theory]
        [InlineData("sheriff")]
        [InlineData("maher")]
        [InlineData("salwa")]
        public void FindByNameTest(string employeeName)
        {
            //prepration
            _employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Name == employeeName))
                .Returns(_employeesQuery.Where(e => e.Name == employeeName));
            IQueryable<Employee> expectedValue = _employeesRepoMoc.Object.FindByCondition(e => e.Name == employeeName);

            //Acction
            IQueryable<Employee> actualValue = _employeesService.FindByCondition(e => e.Name == employeeName);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("sheriff")]
        [InlineData("maher")]
        [InlineData("salwa")]
        public void GetWhereWithDepartmentTest(string employeeDep)
        {
            //prepration
            _employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Department == employeeDep))
                .Returns(_employeesQuery.Where(e => e.Department == employeeDep));
            IQueryable<Employee> expectedValue = _employeesRepoMoc.Object.FindByCondition(e => e.Department == employeeDep);

            //Acction
            IQueryable<Employee> actualValue = _employeesService.FindByCondition(e => e.Department == employeeDep);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
