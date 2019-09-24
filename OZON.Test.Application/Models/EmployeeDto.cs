using System;
using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;
using OZON.Test.Domain.Entities.Enums;

namespace OZON.Test.Application.Models
{
    public class EmployeeDto : IEmployeeDto
    {
        public EmployeeDto()
        {
            ReportedEmployees = new HashSet<EmployeeDto>();
            Bonuses = new List<BonusDto>();
        }
        public int? ReportToId { get; set; }
        public EmployeeDto ReportTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public Departments Department { get; set; }
        public List<BonusDto> Bonuses { get; set; }
        public int Id { get; set; }
        public IEnumerable<EmployeeDto> ReportedEmployees { get; set; }
        public IEmployee GetMappedModel(IMapper mapper) =>
            mapper.Map<IEmployee>(this);
    }
}