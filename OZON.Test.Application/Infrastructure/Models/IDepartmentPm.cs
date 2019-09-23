using System.Collections.Generic;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IDepartmentPm : IDto<IDepartment>
    {
        IEnumerable<EmployeePm> Employees { get; set; } 
        string DepartmentName { get; set; }
    }
}