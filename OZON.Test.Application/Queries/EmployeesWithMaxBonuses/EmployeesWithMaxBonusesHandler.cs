using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.EmployeesWithMaxBonuses
{
    public class EmployeesWithMaxBonusesHandler
        : AbstractRequestHandler, IRequestHandler<EmployeesWithMaxBonusesRequest, IDictionary<IDepartment, Dictionary<IEmployee, decimal>>>
    {
        public EmployeesWithMaxBonusesHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public async Task<IDictionary<IDepartment, Dictionary<IEmployee, decimal>>> Handle(EmployeesWithMaxBonusesRequest request,
            CancellationToken cancellationToken)
        {
            var bonuses = await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Bonuses)
                .GroupBy(x => x.Department)
                .ToDictionaryAsync(x => x.Key.GetMappedModel(_mapper),
                    x =>
                    {
                        var maxBonus = x.Key.Employees.OrderByDescending(e => e.Bonuses.Sum(b => b.BonusAmount)).First()
                            .Bonuses.Sum(b => b.BonusAmount);
                        return x.Key.Employees.Where(e => e.Bonuses.Sum(b => b.BonusAmount) == maxBonus)
                            .ToDictionary(e => e.GetMappedModel(_mapper), _ => maxBonus);
                    });

            return bonuses;
        }
    }
}