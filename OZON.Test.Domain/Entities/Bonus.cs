using System;
using OZON.Test.Domain.Entities.Abstractions;
using OZON.Test.Domain.Exceptions;

namespace OZON.Test.Domain.Entities
{
    public class Bonus : IBonus
    {
        public Bonus(IEmployee employee, DateTime bonusDate, decimal bonusAmount)
        {
            Employee = employee ?? throw new DomainException("Employee cannot be null", GetType());
            BonusAmount = bonusAmount;
            BonusDate = bonusDate;
        }
        public IEmployee Employee { get; }
        public DateTime BonusDate { get; }
        public decimal BonusAmount { get; }
    }
}