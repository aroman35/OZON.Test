using System;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Models
{
    public class BonusPm : IBonusPm
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeePm Employee { get; set; }
        public DateTime BonusDate { get; set; }
        public decimal BonusAmount { get; set; }

        public IBonus GetMappedModel(IMapper mapper) =>
            mapper.Map<IBonus>(this);
    }
}