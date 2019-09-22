using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Domain.Entities
{
    public class Department : IDepartment
    {
        public Department(string name) => DepartmentName = name;
        public string DepartmentName { get; }
    }
}