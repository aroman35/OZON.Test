using System;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IBonusDto : IDto <IBonus>
    {
        int EmployeeId { get; set; }
        EmployeeDto Employee { get; set; }
        DateTime BonusDate { get; set; }
        decimal BonusAmount { get; set; }
    }
}