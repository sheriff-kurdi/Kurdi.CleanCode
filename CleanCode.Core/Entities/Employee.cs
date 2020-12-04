using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public void Promotion(double promotion)
        {
            Salary += promotion;
        }

        public void Deduction(double deduction)
        {
            Salary -= deduction;
        }

        public void ChangeDepartment(string department)
        {
            Department = department;
        }
    }
}
