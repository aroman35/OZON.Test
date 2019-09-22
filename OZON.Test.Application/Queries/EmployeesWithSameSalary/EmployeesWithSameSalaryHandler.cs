using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.EmployeesWithSameSalary
{
    public class EmployeesWithSameSalaryHandler
        : AbstractRequestHandler, IRequestHandler<EmployeesWithSameSalaryRequest, IDictionary<decimal, IEnumerable<IEmployee>>>
    {
        public EmployeesWithSameSalaryHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }
        
        public async Task<IDictionary<decimal, IEnumerable<IEmployee>>> Handle(EmployeesWithSameSalaryRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Employees
                .AsNoTracking()
                .GroupBy(x => x.Salary)
                .OrderBy(x => x.Key)
                .ToDictionaryAsync(x => x.Key,
                    x => x.ToHashSet().Select(model =>
                        model.GetMappedModel(_mapper)),
                    cancellationToken: cancellationToken);
            
            return result;
        }
    }
}