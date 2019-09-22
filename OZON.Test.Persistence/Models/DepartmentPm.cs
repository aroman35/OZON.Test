using System;
using System.Collections.Generic;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Persistence.Models
{
    public class DepartmentPm : IDepartmentPm
    {
        public DepartmentPm() =>
            Employees = new HashSet<IEmployeePm>();
        
        public Guid Id { get; set; }
        public IEnumerable<IEmployeePm> Employees { get; set; }
        public string DepartmentName { get; set; }
        
        public IDepartment GetMappedModel(IMapper mapper) =>
            mapper.Map<IDepartment>(this);
    }
}