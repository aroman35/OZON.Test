using System.Collections.Generic;

namespace OZON.Test.Domain.Entities.Abstractions
{
    public interface ITeam : IDomainEntity
    {
        IEmployee Lead { get; }
        IEnumerable<IEmployee> Members { get; }
    }
}