using System;
using OZON.Test.Domain.Entities;

namespace OZON.Test.Application.Models
{
    public interface IEmployeePm : IEmployee, IDto
    {
        Guid DepartmentId { get; }
    }
}