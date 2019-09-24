using System;
using System.Collections.Generic;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;
using OZON.Test.Domain.Entities.Enums;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IEmployeeDto : IDto<IEmployee>
    {
        int? ReportToId { get; set; }
        EmployeeDto ReportTo { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }
        DateTime JoiningDate { get; set; }
        Departments Department { get; set; }
        List<BonusDto> Bonuses { get; set; }
        IEnumerable<EmployeeDto> ReportedEmployees { get; set; }
    }
}