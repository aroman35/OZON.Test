using System.Collections.Generic;
using System.Linq;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Api.ViewDataModels
{
    public class EmployeeWithBestBonus
    {
        public EmployeeWithBestBonus(IDepartment dept, Dictionary<IEmployee, decimal> source)
        {
            DepartmentName = dept.DepartmentName;
            Employees = source.Select(x =>
                new EmployeeBonusModel{Employee = $"{x.Key.FirstName} {x.Key.LastName}", TotalBonus = x.Value})
                .ToList();
        }
        
        public string DepartmentName { get; set; }
        public List<EmployeeBonusModel> Employees { get; set; }
        
        public class EmployeeBonusModel
        {
            public string Employee { get; set; }
            public decimal TotalBonus { get; set; }
        }
    }
}