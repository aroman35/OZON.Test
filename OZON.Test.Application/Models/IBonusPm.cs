using System;
using OZON.Test.Domain.Entities;

namespace OZON.Test.Application.Models
{
    public interface IBonusPm : IBonus, IDto
    {
        Guid EmployeeId { get; }
    }
}