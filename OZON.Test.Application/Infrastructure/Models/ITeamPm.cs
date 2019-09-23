using System.Collections.Generic;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface ITeamPm : IDto<ITeam>
    {
        int LeadId { get; set; }
        EmployeePm Lead { get; set; }
        IEnumerable<EmployeePm> Members { get; set; }
    }
}