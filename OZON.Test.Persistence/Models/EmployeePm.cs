using System;
using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Persistence.Models
{
    public class EmployeePm : IEmployeePm
    {
        public EmployeePm() => Bonuses = new HashSet<IBonusPm>();
        public Guid DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public IDepartmentPm Department { get; set; }
        public IEnumerable<IBonusPm> Bonuses { get; set; }
        public Guid Id { get; set; }
        
        public IEmployee GetMappedModel(IMapper mapper) =>
            mapper.Map<IEmployee>(this);
    }
}