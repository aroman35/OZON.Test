using System;
using System.Collections.Generic;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IEmployeePm : IDto<IEmployee>
    {
        int DepartmentId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }
        DateTime JoiningDate { get; set; }
        DepartmentPm Department { get; set; }
        IEnumerable<BonusPm> Bonuses { get; set; }
        
        int? TeamId { get; set; }
        DreamTeamPm Team { get; set; }
    }
}