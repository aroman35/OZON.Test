using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Models
{
    public class DreamTeamPm : ITeamPm
    {
        public DreamTeamPm() =>
            Members = new HashSet<EmployeePm>();
        public int Id { get; set; }
        public int LeadId { get; set; }
        public EmployeePm Lead { get; set; }
        public IEnumerable<EmployeePm> Members { get; set; }

        public ITeam GetMappedModel(IMapper mapper) =>
            mapper.Map<ITeam>(this);
    }
}