using System;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Persistence.Models
{
    public class BonusPm : IBonusPm
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public IEmployeePm Employee { get; set; }
        public DateTime BonusDate { get; set; }
        public decimal BonusAmount { get; set; }

        public IBonus GetMappedModel(IMapper mapper) =>
            mapper.Map<IBonus>(this);
    }
}