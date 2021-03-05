using Kurdi.CleanCode.Core.Entities;
using System;
using Xunit;

namespace Kurdi.CleanCode.Test
{
    public class EmployeeEntityTest
    {
        Employee employee;
        public EmployeeEntityTest()
        {
             employee = new Employee()
             {
                 Name = "sheriff",
                 Department = "Accountitng",
                 Salary = 10,
             };      
        }

        [Fact]
        public void PromotionTest()
        {
            //prep
            double expectedSalary = 15;
            //act
            employee.Promotion(5);
            //assert
            Assert.Equal(expectedSalary, employee.Salary);
        }

        [Fact]
        public void DeductionTest()
        {
            //prep
            double expectedSalary = 5;
            //act
            employee.Deduction(5);
            //assert
            Assert.Equal(expectedSalary, employee.Salary);
        }
    }
}
