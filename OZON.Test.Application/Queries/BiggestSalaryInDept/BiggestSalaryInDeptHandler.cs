using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.BiggestSalaryInDept
{
    public class BiggestSalaryInDeptHandler
        : AbstractRequestHandler, IRequestHandler<BiggestSalaryInDeptRequest, IDictionary<string, IEmployee>>

    {
        public BiggestSalaryInDeptHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IDictionary<string, IEmployee>> Handle(BiggestSalaryInDeptRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _context.Departments.Include(x => x.Employees)
                .ToDictionaryAsync(x => x.DepartmentName,
                    x => _mapper.Map<IEmployee>(x.Employees.OrderBy(e => e.Salary).Last()),
                    cancellationToken);
            return result;
        }
    }
}