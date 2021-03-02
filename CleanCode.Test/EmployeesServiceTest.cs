using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using CleanCode.Services;
using CleanCode.Services.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CleanCode.Test
{
    public class EmployeesServiceTest
    {

        Mock<IEmployeesRepo> employeesRepoMoc;
        IEmployeeService employeesService;
        IQueryable<Employee> employeesQuery;
        List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id = 1, Department="IT", Name= "sheriff", Salary = 10},
            new Employee(){Id = 2, Department="acc", Name= "maher", Salary = 5},
            new Employee(){Id = 3, Department="finance", Name= "mohsen", Salary = 8},


        };
        
        public EmployeesServiceTest()
        {
            employeesRepoMoc = new Mock<IEmployeesRepo>();
            employeesService = new EmployeeService(employeesRepoMoc.Object);
            employeesQuery  = employees.AsQueryable();

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(22)]

        public void GetByIdTest(int employeeId)
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindByCondition( e => e.Id == employeeId))
                .Returns(employeesQuery.Where(e => e.Id == employeeId));
            var expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId);

            //Acction
            var actualValue = employeesService.FindByCondition(e => e.Id == employeeId);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void FindAllTest()
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindAll(9, 1)).Returns(employeesQuery);
            IQueryable<Employee> expectedValue = employeesRepoMoc.Object.FindAll(9, 1);

            //Acction
            IQueryable<Employee> actualValue = employeesService.FindAll(9, 1);

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
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Id == employeeId))
                .Returns(employeesQuery.Where(e => e.Id == employeeId));
            IQueryable<Employee> expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId);

            //Acction
            IQueryable<Employee> actualValue = employeesService.FindByCondition(e => e.Id == employeeId);

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
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Name == employeeName))
                .Returns(employeesQuery.Where(e => e.Name == employeeName));
            IQueryable<Employee> expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Name == employeeName);

            //Acction
            IQueryable<Employee> actualValue = employeesService.FindByCondition(e => e.Name == employeeName);

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
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Department == employeeDep))
                .Returns(employeesQuery.Where(e => e.Department == employeeDep));
            IQueryable<Employee> expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Department == employeeDep);

            //Acction
            IQueryable<Employee> actualValue = employeesService.FindByCondition(e => e.Department == employeeDep);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
