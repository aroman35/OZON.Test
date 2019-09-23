using System;
using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Models
{
    public class EmployeePm : IEmployeePm
    {
        public EmployeePm() => Bonuses = new HashSet<BonusPm>();
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public DepartmentPm Department { get; set; }
        public IEnumerable<BonusPm> Bonuses { get; set; }
        public int? TeamId { get; set; }
        public DreamTeamPm Team { get; set; }
        public int Id { get; set; }
        
        public IEmployee GetMappedModel(IMapper mapper) =>
            mapper.Map<IEmployee>(this);
    }
}