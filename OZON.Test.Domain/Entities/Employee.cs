using System;
using System.Collections.Generic;
using OZON.Test.Domain.Entities.Abstractions;
using OZON.Test.Domain.Entities.Enums;
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
            Departments department,
            IEmployee reportTo = default)
        {
            if (string.IsNullOrEmpty(firstName)) throw new DomainException("First name cannot be null", GetType());
            if (string.IsNullOrEmpty(lastName)) throw new DomainException("Last name cannot be null", GetType());
            if (salary <= 25000M) throw new DomainException("The minimum salary for our company is 25 000 :)", GetType());

            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            JoiningDate = joiningDate;
            Department = department;
            ReportTo = reportTo;
            Bonuses = new HashSet<IBonus>();
        }
        public IEmployee ReportTo { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Salary { get; }
        public DateTime JoiningDate { get; }
        public Departments Department { get; }
        public void AddBonus(decimal amount)
        {
            Bonuses.Add(new Bonus(this, DateTime.Now, amount));
        }

        public ICollection<IBonus> Bonuses { get; }
        

        public override string ToString() =>
            $"{FirstName} {LastName}";
    }
}