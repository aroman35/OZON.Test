using System;
using OZON.Test.Domain.Entities.Abstractions;
using OZON.Test.Domain.Exceptions;

namespace OZON.Test.Domain.Entities
{
    public class Employee : IEmployee
    {
        public Employee(
            string firstName,
            string lastName,
            decimal salary,
            DateTime joiningDate,
            IDepartment department)
        {
            if (string.IsNullOrEmpty(firstName)) throw new DomainException("First name cannot be null", GetType());
            if (string.IsNullOrEmpty(lastName)) throw new DomainException("Last name cannot be null", GetType());
            if (salary <= 25000M) throw new DomainException("The minimum salary for our company is 25 000 :)", GetType());

            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            JoiningDate = joiningDate;
            Department = department;
        }
        
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; }
        public DateTime JoiningDate { get; }
        public IDepartment Department { get; }
    }
}