using System.Collections.Generic;
using MediatR;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.EmployeesWithSameSalary
{
    public class EmployeesWithSameSalaryRequest : IRequest<IDictionary<decimal, IEnumerable<IEmployee>>>
    {
        
    }
}