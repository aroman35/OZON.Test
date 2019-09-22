using System;
using System.Collections.Generic;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IEmployeePm : IDto<IEmployee>
    {
        Guid DepartmentId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }
        DateTime JoiningDate { get; set; }
        IDepartmentPm Department { get; set; }
        IEnumerable<IBonusPm> Bonuses { get; set; }
    }
}