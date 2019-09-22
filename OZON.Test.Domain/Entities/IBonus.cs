using System;

namespace OZON.Test.Domain.Entities
{
    public interface IBonus
    {
        IEmployee Employee { get; }
        DateTime BonusDate { get; }
        decimal BonusAmount { get; }
    }
}