using System;
using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Persistence.Models
{
    public class DreamTeamPm : ITeamPm
    {
        public DreamTeamPm() =>
            Members = new HashSet<IEmployeePm>();
        public Guid Id { get; set; }
        public Guid LeadId { get; set; }
        public IEmployee Lead { get; set; }
        public IEnumerable<IEmployeePm> Members { get; set; }

        public ITeam GetMappedModel(IMapper mapper) =>
            mapper.Map<ITeam>(this);
    }
}