using CleanCode.Core.Contracts;
using CleanCode.Core.Entities;
using CleanCode.Services;
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
        IEmployeesService employeesService;
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
            employeesRepoMoc.Setup(x => x.GetById(employeeId)).Returns(employees.Where(e => e.Id == employeeId).FirstOrDefault());
            Employee expectedValue = employeesRepoMoc.Object.GetById(employeeId);

            //Acction
            Employee actualValue = employeesService.GetById(employeeId);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GetAllTest()
        {
            //prepration
            employeesRepoMoc.Setup(x => x.GetAll()).Returns(employees);
            var expectedValue = employeesRepoMoc.Object.GetAll();

            //Acction
            var actualValue = employeesService.GetAll();

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
            employeesRepoMoc.Setup(x => x.GetWhere(e => e.Id == employeeId)).Returns(employees.Where(e => e.Id == employeeId).ToList());
            Employee expectedValue = employeesRepoMoc.Object.GetById(employeeId);

            //Acction
            Employee actualValue = employeesService.GetById(employeeId);

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
            employeesRepoMoc.Setup(x => x.GetWhere(e => e.Name == employeeName)).Returns(employees.Where(e => e.Name == employeeName).ToList());
            List<Employee> expectedValue = employeesRepoMoc.Object.GetWhere(e => e.Name == employeeName);

            //Acction
            List<Employee> actualValue = employeesService.GetWhere(e => e.Name == employeeName);

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
            employeesRepoMoc.Setup(x => x.GetWhere(e => e.Department == employeeDep)).Returns(employees.Where(e => e.Department == employeeDep).ToList());
            List<Employee> expectedValue = employeesRepoMoc.Object.GetWhere(e => e.Department == employeeDep);

            //Acction
            List<Employee> actualValue = employeesService.GetWhere(e => e.Department == employeeDep);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
