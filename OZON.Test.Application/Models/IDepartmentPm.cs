using System.Collections.Generic;
using OZON.Test.Domain.Entities;

namespace OZON.Test.Application.Models
{
    public interface IDepartmentPm<out TEmployee> : IDepartment, IDto
        where TEmployee : IEmployeePm
    {
        IEnumerable<TEmployee> Employees { get; }
    }
}