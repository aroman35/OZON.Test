using System;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IBonusPm : IDto <IBonus>
    {
        int EmployeeId { get; set; }
        EmployeePm Employee { get; set; }
        DateTime BonusDate { get; set; }
        decimal BonusAmount { get; set; }
    }
}