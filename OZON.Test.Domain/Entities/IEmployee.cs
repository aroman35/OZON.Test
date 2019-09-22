using System;

namespace OZON.Test.Domain.Entities
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        decimal Salary { get; }
        DateTime JoiningDate { get; }
        IDepartment Department { get; }
    }
}