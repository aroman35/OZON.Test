using System;
using System.Collections.Generic;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface ITeamPm : IDto<ITeam>
    {
        Guid LeadId { get; set; }
        IEmployee Lead { get; set; }
        IEnumerable<IEmployeePm> Members { get; set; }
    }
}