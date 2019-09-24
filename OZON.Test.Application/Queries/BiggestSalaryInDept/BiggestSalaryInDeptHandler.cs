using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Domain.Extensions;

namespace OZON.Test.Application.Queries.BiggestSalaryInDept
{
    public class BiggestSalaryInDeptHandler
        : AbstractRequestHandler, IRequestHandler<BiggestSalaryInDeptRequest, IDictionary<string, IEnumerable<string>>>

    {
        public BiggestSalaryInDeptHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IDictionary<string, IEnumerable<string>>> Handle(BiggestSalaryInDeptRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _context.Employees
                .GroupBy(x => x.Department)
                .ToDictionaryAsync(x => x.Key.GetDescription(),
                    x =>
                    {
                        var biggestSalary = x.OrderByDescending(e => e.Salary).First().Salary;
                        return x.Where(e => e.Salary == biggestSalary)
                            .Select(e => e.GetMappedModel(_mapper).ToString());
                    }, cancellationToken);
            
            return result;
        }
    }
}