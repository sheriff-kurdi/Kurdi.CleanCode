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

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(22)]

        public void GetByIdTest(int employeeId)
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindByCondition( e => e.Id == employeeId).FirstOrDefault()).Returns(employees.Where(e => e.Id == employeeId).FirstOrDefault());
            Employee expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId).FirstOrDefault();

            //Acction
            Employee actualValue = employeesService.FindByCondition(e => e.Id == employeeId).FirstOrDefault();

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GetAllTest()
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindAll(9,1).ToList()).Returns(employees);
            var expectedValue = employeesRepoMoc.Object.FindAll(9, 1);

            //Acction
            var actualValue = employeesService.FindAll(9, 1);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(22)]
        public void GetWhereWithIdTest(int employeeId)
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Id == employeeId).ToList()).Returns(employees.Where(e => e.Id == employeeId).ToList());
            Employee expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Id == employeeId).FirstOrDefault();

            //Acction
            Employee actualValue = employeesService.FindByCondition(e => e.Id == employeeId).FirstOrDefault();

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }


        [Theory]
        [InlineData("sheriff")]
        [InlineData("maher")]
        [InlineData("salwa")]
        public void GetWhereWithNameTest(string employeeName)
        {
            //prepration
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Name == employeeName).ToList()).Returns(employees.Where(e => e.Name == employeeName).ToList());
            List<Employee> expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Name == employeeName).ToList();

            //Acction
            List<Employee> actualValue = employeesService.FindByCondition(e => e.Name == employeeName).ToList();

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
            employeesRepoMoc.Setup(x => x.FindByCondition(e => e.Department == employeeDep).ToList()).Returns(employees.Where(e => e.Department == employeeDep).ToList());
            List<Employee> expectedValue = employeesRepoMoc.Object.FindByCondition(e => e.Department == employeeDep).ToList();

            //Acction
            List<Employee> actualValue = employeesService.FindByCondition(e => e.Department == employeeDep).ToList();

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
