using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Models
{
    public class DepartmentPm : IDepartmentPm
    {
        public DepartmentPm() =>
            Employees = new HashSet<EmployeePm>();
        
        public int Id { get; set; }
        public IEnumerable<EmployeePm> Employees { get; set; }
        public string DepartmentName { get; set; }
        
        public IDepartment GetMappedModel(IMapper mapper) =>
            mapper.Map<IDepartment>(this);
    }
}