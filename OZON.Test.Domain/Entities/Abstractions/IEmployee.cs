using System;

namespace OZON.Test.Domain.Entities.Abstractions
{
    public interface IEmployee : IDomainEntity
    {
        string FirstName { get; }
        string LastName { get; }
        decimal Salary { get; }
        DateTime JoiningDate { get; }
        IDepartment Department { get; }
    }
}