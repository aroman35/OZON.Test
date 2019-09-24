using System.Collections.Generic;
using System.Linq;
using OZON.Test.Application.Models;

namespace OZON.Test.Application.Queries.GetTeamComposition
{
    public class EmployeeTeamModel
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeTeamModel> Team { get; set; }
        
        public EmployeeTeamModel(EmployeeDto employee)
        {
            Name = employee.FirstName;
            Team = employee.ReportedEmployees.Select(x => new EmployeeTeamModel(x));
        }
    }
}