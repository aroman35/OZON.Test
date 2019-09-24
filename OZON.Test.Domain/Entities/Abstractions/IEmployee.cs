using System;
using System.Collections;
using System.Collections.Generic;
using OZON.Test.Domain.Entities.Enums;

namespace OZON.Test.Domain.Entities.Abstractions
{
    public interface IEmployee : IDomainEntity
    {
        IEmployee ReportTo { get; }
        string FirstName { get; }
        string LastName { get; }
        decimal Salary { get; }
        DateTime JoiningDate { get; }
        Departments Department { get; }
        void AddBonus(decimal amount);
        ICollection<IBonus> Bonuses { get; }
    }
}