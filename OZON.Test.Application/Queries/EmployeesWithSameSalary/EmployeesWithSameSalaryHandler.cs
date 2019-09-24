using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;

namespace OZON.Test.Application.Queries.EmployeesWithSameSalary
{
    public class EmployeesWithSameSalaryHandler
        : AbstractRequestHandler, IRequestHandler<EmployeesWithSameSalaryRequest, IDictionary<decimal, IEnumerable<string>>>
    {
        public EmployeesWithSameSalaryHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
        
        public async Task<IDictionary<decimal, IEnumerable<string>>> Handle(EmployeesWithSameSalaryRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Employees
                .GroupBy(x => x.Salary)
                .OrderBy(x => x.Key)
                .ToDictionaryAsync(x => x.Key,
                    x => x.Select(e => e.GetMappedModel(_mapper).ToString()), cancellationToken);
            
            return result;
        }
    }
}