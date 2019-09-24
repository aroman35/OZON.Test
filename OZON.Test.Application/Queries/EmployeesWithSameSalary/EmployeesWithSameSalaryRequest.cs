using System.Collections.Generic;
using MediatR;

namespace OZON.Test.Application.Queries.EmployeesWithSameSalary
{
    public class EmployeesWithSameSalaryRequest : IRequest<IDictionary<decimal, IEnumerable<string>>>
    {
        
    }
}