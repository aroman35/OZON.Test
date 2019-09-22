using System;

namespace OZON.Test.Domain.Entities.Abstractions
{
    public interface IBonus : IDomainEntity
    {
        IEmployee Employee { get; }
        DateTime BonusDate { get; }
        decimal BonusAmount { get; }
    }
}