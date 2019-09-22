using System;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IBonusPm : IDto <IBonus>
    {
        Guid EmployeeId { get; set; }
        IEmployeePm Employee { get; set; }
        DateTime BonusDate { get; set; }
        decimal BonusAmount { get; set; }
    }
}